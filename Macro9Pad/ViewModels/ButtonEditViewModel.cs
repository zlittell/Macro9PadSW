using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Caliburn.Micro;
using Macro9Pad.Helpers;
using Macro9Pad.Models;

namespace Macro9Pad.ViewModels
{
    public class ButtonEditViewModel : Screen
    {
        private ButtonModel buttonEdit { get; set; }

        public ButtonEditViewModel(ButtonModel button)
        {
            this.buttonEdit = button;
        }

        public ButtonModel ButtonEdit
        {
            get
            {
                return this.buttonEdit;
            }
        }

        public IEnumerable<HIDKeyboardScanCode> BindableKeyboardScanCodes
        {
            get
            {
                return Enum.GetValues(typeof(HIDKeyboardScanCode)).Cast<HIDKeyboardScanCode>();
            }
        }

        public HIDKeyboardScanCode SelectedScancode
        {
            get
            {
                return (HIDKeyboardScanCode)Enum.ToObject(typeof(HIDKeyboardScanCode), this.buttonEdit.Button);
            }

            set
            {
                this.buttonEdit.Button = (byte)value;
            }
        }

        /// <summary>
        /// Processes a check box change.
        /// </summary>
        /// <param name="callingElement">Checkbox that has been altered.</param>
        public void ModifierCheckBoxCommand(CheckBox callingElement)
        {
            byte modifier = 0x00;

            switch (callingElement?.Name)
            {
                case "LeftControl":
                {
                    modifier = (byte)HIDKeyboardModifierMasks.LeftControl;
                    break;
                }

                case "LeftShift":
                {
                    modifier = (byte)HIDKeyboardModifierMasks.LeftShift;
                    break;
                }

                case "LeftAlt":
                {
                    modifier = (byte)HIDKeyboardModifierMasks.LeftAlt;
                    break;
                }

                case "LeftMeta":
                {
                    modifier = (byte)HIDKeyboardModifierMasks.LeftMeta;
                    break;
                }

                case "RightControl":
                {
                    modifier = (byte)HIDKeyboardModifierMasks.RightControl;
                    break;
                }

                case "RightShift":
                {
                    modifier = (byte)HIDKeyboardModifierMasks.RightShift;
                    break;
                }

                case "RightAlt":
                {
                    modifier = (byte)HIDKeyboardModifierMasks.RightAlt;
                    break;
                }

                case "RightMeta":
                {
                    modifier = (byte)HIDKeyboardModifierMasks.RightMeta;
                    break;
                }

                default:
                {
                    throw new ArgumentOutOfRangeException(callingElement.Name.ToString(), "There is no switch case for handling this element.");
                }
            }

            // Mask modifier logic
            if ((bool)callingElement.IsChecked)
            {
                this.buttonEdit.Modifier |= modifier;
            }
            else
            {
                this.buttonEdit.Modifier &= (byte)~modifier;
            }
        }
    }
}
