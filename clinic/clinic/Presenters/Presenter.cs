using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Presenters
{
    public abstract class Presenter
    {
        protected string[] dateTimeFormats = {"d/M/yyyy","dd/M/yyyy","d/MM/yyyy","dd/MM/yyyy", "d-M-yyyy", "dd-M-yyyy"
                                            , "d-MM-yyyy","dd-MM-yyyy" };
        public bool ValidateStringInput(string input, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = "Vui lòng nhập";
                return false;
            }
            errorMessage = "";
            return true;
        }
        public bool ValidateDateTimeInput(string input,out string errorMessage)
        {
            if (ValidateStringInput(input, out errorMessage) == false) return false;
            try
            {
                DateTime dateTime = DateTime.ParseExact(input,dateTimeFormats,CultureInfo.InvariantCulture,DateTimeStyles.None);
            }
            catch 
            {
                errorMessage = "Nhập ngày/tháng/năm";
                return false;
            }
            errorMessage = "";
            return true;
        }
        public bool ValidateNumberInput(string input, out string errorMessage)
        {
            if (ValidateStringInput(input,out errorMessage) == false) return false;
            try
            {
                Int64 number = Int64.Parse(input);
                if (number <= 0)
                {
                    errorMessage = "Số phải lớn hơn 0";
                    return false;
                }
            }
            catch
            {
                errorMessage = "Vui Lòng Nhập Số";
                return false;
            }
            errorMessage = "";
            return true;
        }
    }
}
