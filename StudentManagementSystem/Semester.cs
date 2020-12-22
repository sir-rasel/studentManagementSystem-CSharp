using System;

namespace StudentManagementSystem
{
    public class Semester : ICreateObject, IFormatedOutput
    {
        // Private Members
        private string _semesterCode;
        private string _year;

        // Properties
        public string semesterCode
        {
            get
            {
                return _semesterCode ?? "NULL";
            }
            set
            {
                if(value.ToLower() == "summer" || value.ToLower() == "fall" || value.ToLower() == "spring")
                {
                    _semesterCode = value;
                }
                else
                {
                    _semesterCode = default;
                    Console.WriteLine("Sorry allwed semester code are: Summer, Spring, Fall. Choose one of them.");
                }
            }
        }

        public string year
        {
            get
            {
                return _year ?? "NULL";
            }

            set
            {
                if(value.Length == 4 && value.isDigitOnly() == true)
                {
                    _year = value;
                }
                else
                {
                    _year = default;
                    Console.WriteLine("Please Give a valid year.");
                }
            }
        }

        // Indexer

        public dynamic this[int index]
        {
            get
            {
                if(index == 0)
                {
                    return semesterCode;
                }
                else
                {
                    return year;
                }
            }

            set
            {
                if(index == 0)
                {
                    semesterCode = value;
                }
                else
                {
                    year = value;
                }
            }
        }

        //Constructors
        public Semester()
        {
            _semesterCode = default;
            _year = default;
        }

        public Semester(string code, string year)
        {
            semesterCode = code;
            this.year = year;
        }

        //Methods
        public dynamic createDeepCopy()
        {
            Semester newSemesterObject = new Semester(semesterCode, year);
            return newSemesterObject;
        }

        public void getFormatedOutput()
        {
            Console.WriteLine("Semester Code : {0}", semesterCode);
            Console.WriteLine("Year : {0}", year);
        }

    }
}
