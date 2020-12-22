using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    public enum Department
    {
        None,
        ComputerScience,
        BBA,
        ENGLISH
    }

    public enum Degree
    {
        None,
        BSC,
        BBA,
        BA,
        MSC,
        MBA,
        MA
    }

    public class Student : ICreateObject, IFormatedOutput
    {
        // Private members
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _studentID;
        private Semester _joiningBatch;
        private Department _department;
        private Degree _degree;
        private List<Semester> _attendedSemester;
        private List<List<Course>> _courseInEachSemester;

        // Properties
        public string firstName
        {
            get
            {
                return _firstName ?? "None";
            }
            set
            {
                _firstName = value;
            }
        }

        public string middleName
        {
            get
            {
                return _middleName ?? "None";
            }
            set
            {
                _middleName = value;
            }
        }

        public string lastName
        {
            get
            {
                return _lastName ?? "None";
            }
            set
            {
                _lastName = value;
            }
        }

        public string studentID
        {
            get
            {
                return _studentID ?? "None";
            }
            set
            {
                var splitString = value.Split('-');
                if(splitString.Length == 3)
                {
                    _studentID = value;
                }
                else
                {
                    _studentID = default;
                    Console.WriteLine("Student ID should be in the format XXX-XXX-XXX.");
                }
            }
        }


        public Semester joiningBatch
        {
            get
            {
                return _joiningBatch;
            }
            set
            {
                _joiningBatch = value;
            }
        }

        public dynamic department
        {
            get
            {
                return _department;
            }
            set
            {
                int val = Convert.ToInt32(value);
                if(val <=0 || val > 3)
                {
                    _department = Department.None;
                    Console.WriteLine("Value Should be in range 1-3.");
                }
                else _department = (Department)val;
            }
        }

        public dynamic degree
        {
            get
            {
                return _degree;
            }
            set
            {
                int val = Convert.ToInt32(value);
                if (val <= 0 || val > 6)
                {
                    _degree = Degree.None;
                    Console.WriteLine("Value Should be in range 1-6.");
                }
                else _degree = (Degree)val;
            }
        }

        public List<Semester> attendedSemester
        {
            get
            {
                return _attendedSemester;
            }
            set
            {
                _attendedSemester = value;
            }
        }

        public List<List<Course> > courseInEachSemester
        {
            get
            {
                return _courseInEachSemester;
            }
            set
            {
                _courseInEachSemester = value;
            }
        }

        // Indexer
        public dynamic this[int index]
        {
            get
            {
                if(index == 0)
                {
                    return firstName;
                }
                else if(index == 1)
                {
                    return middleName;
                }
                else if(index == 2)
                {
                    return lastName;
                }
                else if(index == 3)
                {
                    return studentID;
                }
                else if(index == 4)
                {
                    return joiningBatch;
                }
                else if(index == 5)
                {
                    return department;
                }
                else
                {
                    return degree;
                }
            }

            set
            {
                if (index == 0)
                {
                    firstName = value;
                }
                else if (index == 1)
                {
                    middleName = value;
                }
                else if (index == 2)
                {
                    lastName = value;
                }
                else if(index == 3)
                {
                    studentID = value;
                }
                else if (index == 4)
                {
                    joiningBatch = value;
                }
                else if (index == 5)
                {
                    department = value;
                }
                else
                {
                    degree = value;
                }
            }
        }

        // Constructors
        public Student()
        {
            _firstName = default;
            _middleName = default;
            _lastName = default;
            _studentID = default;
            _joiningBatch = default;
            _department = Department.None;
            _degree = Degree.None;
            _attendedSemester = new List<Semester>();
            _courseInEachSemester = new List<List<Course>>();
        }

        public Student(string fName, string mName, string lName, string id, Semester batch, int department,
            int degree, List<Semester> semestersAttended, List<List<Course>> courses)
        {
            firstName = fName;
            middleName = mName;
            lastName = lName;
            studentID = id;
            joiningBatch = batch;
            this.department = department;
            this.degree = degree;
            attendedSemester = semestersAttended;
            courseInEachSemester = courses;
        }

        //methods
        public dynamic createDeepCopy()
        {
            Student newObject = new Student(firstName, middleName, lastName, studentID, joiningBatch, department, degree, attendedSemester, courseInEachSemester);
            return newObject;
        }

        public void getFormatedOutput()
        {
            Console.WriteLine("Student Name : {0} {1} {2}", firstName, middleName, lastName);
            Console.WriteLine("Student ID : {0}", studentID);
            Console.WriteLine("Joining Batch :- ");
            joiningBatch.getFormatedOutput();
            Console.WriteLine("Department: {0}", department);
            Console.WriteLine("Degree: {0}", degree);

            Console.WriteLine("Attended Semesters are :- ");
            foreach(var semester in attendedSemester)
            {
                semester.getFormatedOutput();
            }

            Console.WriteLine("Courses in each semesters are :- ");
            for(int i = 0; i < courseInEachSemester.Count; i++)
            {
                Console.WriteLine($"{attendedSemester[i].semesterCode} : {attendedSemester[i].year}");
                foreach(var course in courseInEachSemester[i])
                {
                    course.getFormatedOutput();
                }
            }
            Console.WriteLine();
        }
    }
}
