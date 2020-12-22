using System;

namespace StudentManagementSystem
{
    public class Course : ICreateObject, IFormatedOutput
    {
        // Private members
        private string _courseID;
        private string _courseName;
        private string _instructorName;
        private int _numberOfCredits;

        // Properties
        public string courseID
        {
            get
            {
                return _courseID ?? "NULL";
            }
            set
            {
                var splitString = value.Split(' ');
                if (splitString.Length == 2 && splitString[0].isAlphabetOnly() == true && splitString[1].isDigitOnly() == true)
                {
                    _courseID = value;
                }
                else
                {
                    _courseID = default;
                    Console.WriteLine("Invalid formated ID. Please enter (XXX YYY) format ID. EX: CSC 101.");
                }
            }
        }

        public string courseName
        {
            get
            {
                return _courseName ?? "NULL";
            }
            set
            {
                _courseName = value;
            }
        }

        public string instructorName
        {
            get
            {
                return _instructorName ?? "NULL";
            }
            set
            {
                _instructorName = value;
            }
        }

        public int numberOfCredits
        {
            get
            {
                return _numberOfCredits;
            }
            set
            {
                if (value.GetType() == typeof(int))
                {
                    _numberOfCredits = value;
                }
                else
                {
                    _numberOfCredits = default;
                    Console.WriteLine("Numbe of credits should be integer type.");
                }
            }
        }

        // Indexer
        public dynamic this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return courseID;
                }
                else if (index == 1)
                {
                    return courseName;
                }
                else if (index == 2)
                {
                    return instructorName;
                }
                else
                {
                    return numberOfCredits;
                }
            }

            set
            {
                if(index == 0)
                {
                    courseID = value;
                }
                else if(index == 1)
                {
                    courseName = value;
                }
                else if(index == 2)
                {
                    instructorName = value;
                }
                else
                {
                    numberOfCredits = value;
                }
            }
        }

        // Constructors
        public Course()
        {
            _courseID = default;
            _courseName = default;
            _instructorName = default;
            _numberOfCredits = default;
        }

        public Course (string id, string courseName, string instructorName, int credits)
        {
            courseID = id;
            this.courseName = courseName;
            this.instructorName = instructorName;
            _numberOfCredits = credits;
        }

        // Methods
        public dynamic createDeepCopy()
        {
            Course newCourseObject = new Course(courseID, courseName, instructorName, numberOfCredits);
            return newCourseObject;
        }

        public void getFormatedOutput()
        {
            Console.WriteLine("Course ID : {0}", courseID);
            Console.WriteLine("Course Name : {0}", courseName);
            Console.WriteLine("Instructor Name : {0}", instructorName);
            Console.WriteLine("Number of Credits : {0}", numberOfCredits);
            Console.WriteLine();
        }
    }
}
