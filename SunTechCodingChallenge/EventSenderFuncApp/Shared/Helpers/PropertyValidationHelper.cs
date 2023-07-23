using System;


namespace EventSenderFuncApp.Shared.Helpers
{
    public static class PropertyValidationHelper
    {
        public static bool ValidateEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; 
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidateDateTime(string datetime)
        {
            try
            {
                DateTime temp;
                if (!DateTime.TryParse(datetime, out temp))
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
