using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BehsamFramework.Util
{
    public static class Utility
    {
        static Utility()
        {
            
        }

        public static string GetUserName(Microsoft.AspNetCore.Http.HttpContext context)
        {
            

            Entity.UserInfoTbl user =
                context.Items["User"] as Entity.UserInfoTbl;
            
            if (user == null)
                return "UnKnown";

            return user.UserName;
        }

        public static string ToPersianDate(this DateTime input)
        {
            var pdt =new  System.Globalization.PersianCalendar();
            try
            {
                return $"{pdt.GetYear(input).ToString("0000")}/{pdt.GetMonth(input).ToString("00")}/{pdt.GetDayOfMonth(input).ToString("00")}"; 
            }
            catch
            {
                return "";
            }
        }
        public static byte GetDayOfWeekPersian(this DateTime dt)
        {
            var pdt = new System.Globalization.PersianCalendar();
            var day = pdt.GetDayOfWeek(dt);

            switch(day)
            {
                case DayOfWeek.Saturday: return 1;
                case DayOfWeek.Sunday: return 2;
                case DayOfWeek.Monday: return 3;
                case DayOfWeek.Tuesday: return 4;
                case DayOfWeek.Wednesday: return 5;
                case DayOfWeek.Thursday: return 6;
                case DayOfWeek.Friday: return 7;
                default: return 0;
            }
        }
        public static string GetDayOfWeekPersianStr(this DateTime dt)
        {
            var pdt = new System.Globalization.PersianCalendar();
            var day = pdt.GetDayOfWeek(dt);

            switch (day)
            {
                case DayOfWeek.Saturday: return "شنبه";
                case DayOfWeek.Sunday: return "یکشنبه";
                case DayOfWeek.Monday: return "دوشنبه";
                case DayOfWeek.Tuesday: return "سه شنبه";
                case DayOfWeek.Wednesday: return "چهارشنبه";
                case DayOfWeek.Thursday: return "پنجشنبه";
                case DayOfWeek.Friday: return "جمعه";
                default: return "نامشخص";
            }
        }
        public static string GetPersianDate(this DateTime dt)
        {
            var pdt = new System.Globalization.PersianCalendar();
            return pdt.GetYear(dt).ToString("0000") + "/" +
                   pdt.GetMonth(dt).ToString("00") + "/" +
                   pdt.GetDayOfMonth(dt).ToString("00");

        }
        public static string GetPersianFullDate(this DateTime dt)
        {
            var day = dt.GetDayOfWeekPersianStr();
            var pdt = dt.GetPersianDate();

            return " روز "+day+" -- مورخ " + pdt;
        }
        public static string GetPersianFullDateTime(this DateTime dt)
        {
            var day = dt.GetDayOfWeekPersianStr();
            var pdt = dt.GetPersianDate();

            return " روز " + day + " -- مورخ " + pdt+" "+dt.GetTime();
        }
        public static string GetTime(this DateTime dt)
        {
            var pdt = new System.Globalization.PersianCalendar();

            return pdt.GetHour(dt).ToString("00") + ":" +
                   pdt.GetMinute(dt).ToString("00") + ":" +
                   pdt.GetSecond(dt).ToString("00");
        }

        public static decimal ToDecimal(this string input)
        {
            try
            {
                try
                {
                    System.Globalization.CultureInfo myInfo = System.Globalization.CultureInfo.InvariantCulture;
                    return Convert.ToDecimal(input, myInfo);
                }
                catch
                {

                }

                try
                {
                    decimal d = Convert.ToDecimal(input, CultureInfo.CurrentCulture);
                    return d;
                }
                catch (Exception ex)
                {

                }

                


                try
                {
                    System.Globalization.CultureInfo myInfo = System.Globalization.CultureInfo.CurrentUICulture;
                    return Convert.ToDecimal(input, myInfo);
                }
                catch
                {

                }

                
                StringBuilder sb = new StringBuilder();
                foreach (char item in input.Trim())
                {
                    if (char.IsDigit(item))
                    {
                        sb.Append(item);
                    }
                    else
                    {
                        sb.Append('.');
                    }
                }

                input = sb.ToString();

                if (input == null)
                {
                    return 0;
                }
                if (string.IsNullOrWhiteSpace(input))
                {
                    return 0;
                }

                if (input.Contains('.'))
                {
                    decimal output = 0M;

                    string[] splitValue = input.Split('.');
                    try
                    {
                        int part1,part2;
                        Int32.TryParse(splitValue[0],out part1);
                        Int32.TryParse(splitValue[1], out part2);

                        output = part1;
                        if(part2>0)
                        {
                            output += part2 / (decimal)Math.Pow(10, splitValue[1].Length);
                        }     
                    }
                    catch 
                    {
                        return 0;
                    }

                    return output;
                }

                return 0;

            }
            catch
            {
                return 0;
            }
        }

        public
            static
            async
            System.Threading.Tasks.Task
            <FluentResults.Result<TValue>>
            Validate<TCommand, TValue>
            (FluentValidation.AbstractValidator<TCommand> validator, TCommand command)
        {
            FluentResults.Result<TValue> result = new FluentResults.Result<TValue>();

            FluentValidation.Results.ValidationResult
                validationResult = await validator.ValidateAsync(instance: command);

            if (validationResult.IsValid == false)
            {
                foreach (var error in validationResult.Errors)
                {
                    result.WithError(errorMessage: error.ErrorMessage);
                }
            }

            return result;
        }


        public
            static
            async
            System.Threading.Tasks.Task
            <FluentResults.Result>
            Validate<TCommand>
            (FluentValidation.AbstractValidator<TCommand> validator, TCommand command)
        {
            FluentResults.Result result = new FluentResults.Result();

            FluentValidation.Results.ValidationResult
                validationResult = await validator.ValidateAsync(instance: command);

            if (validationResult.IsValid == false)
            {
                foreach (var error in validationResult.Errors)
                {
                    result.WithError(errorMessage: error.ErrorMessage);
                }
            }

            return result;
        }
    }
}
