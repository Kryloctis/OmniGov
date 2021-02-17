using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystem
{
    class Error : IError
    {
        private readonly Array _errors;

        public Error(Array errors)
        {
            _errors = errors;
        }

        public string GenerateErrorMessage()
        {
            StringBuilder sb = new StringBuilder($"Please correct the following errors and try again. { Environment.NewLine } { Environment.NewLine }");

            foreach (var error in _errors)
            {
                if (!string.IsNullOrWhiteSpace(error.ToString()))
                {
                    sb.AppendLine($"- {error}");
                }
            }

            return sb.ToString();
        }
    }
}
