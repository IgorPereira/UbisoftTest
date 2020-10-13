using System;

namespace UbisoftTest
{
	public enum VALIDATION_ERROR_TYPES { NONE, OVERFLOW, INVALID_CHARACTER }

    public class ValidationErrorArgs : EventArgs
    {
        public VALIDATION_ERROR_TYPES type;
        public char invalidCharacter;
    }

    public class StringValidationEventDispatcher : EventDispatcher<VALIDATION_ERROR_TYPES, ValidationErrorArgs>
    {

    }
}