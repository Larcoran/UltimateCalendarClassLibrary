﻿using System.Linq;

namespace UltimateCalendarClassLibrary
{
    public class PasswordEncrypter
    {
        private string alphabet = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ0123456789";
        private string encryptedPassword = "";
        
        public string encryptPassword(string passwordToEncrypt)
        {
            encryptedPassword = "";
            foreach (char @char in passwordToEncrypt)
            {
                if (alphabet.Contains(@char))
                {
                    encryptedPassword += alphabet[plusTen(alphabet.IndexOf(@char))];
                }
                else encryptedPassword += @char;
            }
            return encryptedPassword;

        }

        private int plusTen(int number)
        {
            if (number + 10 > 61)
            {
                return (number + 10) - 62;
            }
            else return number + 10;
        }
    }
}
