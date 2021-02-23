using System;

namespace VaquesBackend.Exceptions {
    public class VaquesException: Exception {

        public VaquesException()
        {
        }

        public VaquesException(string message)
            : base(message)
        {
        }

        public VaquesException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}