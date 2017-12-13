using DijitalPazarlama.Data;
using DijitalPazarlama.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijitalPazarlama.Validation
{
    public class Validator
    {
        public bool ValidateInput(string s, int length)
        {
            if (!string.IsNullOrEmpty(s) && s.Length > length)
                return true;
            return false;
        }
        public bool ValidateInput(string text, int lenght, bool onlyInt, bool fixedLength)
        {
            int number;
            bool b = int.TryParse(text, out number);

            if (text.Length >= lenght && b == onlyInt)
            {
                if (fixedLength)
                {
                    if (text.Length != lenght)
                        return false;
                }
                return true;
            }
            return false;
        }
    }
}