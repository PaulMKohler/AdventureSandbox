/*
 *
 *	Adventure Creator
 *	by Chris Burton, 2013-2021
 *	
 *	"Variables.cs"
 * 
 *	This component allows Component variables to be linked to an Animator parameter.
 * 
 */

using UnityEngine;

namespace AC
{

	/** This component allows Component variables to be linked to an Animator parameter. */
	[AddComponentMenu ("Adventure Creator/Logic/Link Variable to Animator")]
	[HelpURL ("https://www.adventurecreator.org/scripting-guide/class_a_c_1_1_link_variable_to_animator.html")]
	public class LinkVariableToAnimator : MonoBehaviour
	{

		#region Variables

		/** The name shared by the Component Variable and the Animator */
		public string sharedVariableName;
		/** The Variables component with the variable to link */
		public Variables variables;
		/** The Animator component with the parameter to link */
		public Animator _animator;

		#endregion


		#region UnityStandards

		private void OnEnable ()
		{
			if (variables == null)
			{
				variables = GetComponent <Variables>();
			}
			if (_animator == null)
			{
				_animator = GetComponent <Animator>();
			}

			if (variables == null)
			{
				ACDebug.LogWarning ("No Variables component found for Link Variable To Animator on " + gameObject, this);
				return;
			}

			if (_animator == null)
			{
				ACDebug.LogWarning ("No Animator component found for Link Variable To Animator on " + gameObject, this);
				return;
			}

			if (string.IsNullOrEmpty (sharedVariableName))
			{
				ACDebug.LogWarning ("No shared variable name set for Link Variable To Animator on " + gameObject, this);
				return;
			}

			GVar linkedVariable = variables.GetVariable (sharedVariableName);
			if (linkedVariable != null)
			{
				if (linkedVariable.link != VarLink.CustomScript)
				{
					ACDebug.LogWarning ("The component variable " + sharedVariableName + " must have its 'Link to' field set to 'Custom Script' in order to link it to an Animator");
				}
			}
			else
			{
				ACDebug.LogWarning ("Variable " + sharedVariableName + " was not found for Link Variable To Animator on " + gameObject, this);
				return;
			}

			EventManager.OnDownloadVariable += OnDownload;
			EventManager.OnUploadVariable += OnUpload;
		}


		private void OnDisable ()
		{
			EventManager.OnDownloadVariable -= OnDownload;
			EventManager.OnUploadVariable -= OnUpload;
		}

		#endregion


		#region PrivateFunctions

		private void OnDownload (GVar variable, Variables variables)
		{
			if (this.variables == variables && variable.label == sharedVariableName)
			{
				switch (variable.type)
				{
					case VariableType.Boolean:
						variable.BooleanValue = _animator.GetBool (sharedVariableName);
						break;

					case VariableType.Integer:
						variable.IntegerValue = _animator.GetInteger (sharedVariableName);
						break;

					case VariableType.Float:
						variable.FloatValue = _animator.GetFloat (sharedVariableName);
						break;

					default:
						break;
				}
			}
		}


		private void OnUpload (GVar variable, Variables variables)
		{
			if (this.variables == variables && variable.label == sharedVariableName)
			{
				switch (variable.type)
				{
					case VariableType.Boolean:
						_animator.SetBool (sharedVariableName, variable.BooleanValue);
						break;

					case VariableType.Integer:
						_animator.SetInteger (sharedVariableName, variable.IntegerValue);
						break;

					case VariableType.Float:
						_animator.SetFloat (sharedVariableName, variable.FloatValue);
						break;

					default:
						break;
				}
			}
		}

		#endregion

	}

}