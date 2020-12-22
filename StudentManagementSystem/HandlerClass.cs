using System;

namespace StudentManagementSystem
{
    internal class HandlerClass
    {
        // Members
        public event Notify processCompleted;
        public string[] studentMassageBox = {"Enter student first name",
                                              "Enter student middle name",
                                              "Enter student last name",
                                              "Enter Student ID in the format XXX-XXX-XXX: ",
                                              "Joining Batch",
                                              "Enter Department: 1 for ComputerScience, 2 for BBA, 3 for English",
                                              "Enter Degree: 1 for BSC, 2 for BBA, 3 for BA, 4 for MSC, 5 for MBA, 6 for MA"
        };

        public string[] semesterMassageBox = {"Enter Semester code: one of the ('Summer', 'Fall', 'Spring')",
                                              "Enter Year in the format XXXX. Like: 2019"
        };

        public string[] courseMassageBox = {"Enter Course id in the format XXX YYY. Like: CSC 101",
                                            "Enter Course Name",
                                            "Enter Instructor name",
                                            "Enter Number of credits"
        };


        // Methods
        protected virtual void onProcessCompleted(params dynamic[] massage)
        {
            processCompleted?.Invoke(massage);
        }

        public Semester inputSemester()
        {
            Semester dumySemester = new Semester();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(semesterMassageBox[i]);
                string temp = Console.ReadLine();
                dumySemester[i] = temp;

                if (dumySemester[i] == "NULL")
                {
                    i--;
                }
            }

            onProcessCompleted("Semester Successfully read.", dumySemester.semesterCode, dumySemester.year);
            Console.WriteLine();

            return dumySemester;
        }

        public Course inputCourse()
        {
            Course dumyCourse = new Course();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(courseMassageBox[i]);
                string temp = Console.ReadLine();

                if (i < 3)
                {
                    dumyCourse[i] = temp;
                    if (dumyCourse[i] == "NULL")
                    {
                        i--;
                    }
                }
                else
                {
                    try
                    {
                        dumyCourse[i] = Convert.ToInt32(temp);
                    }
                    catch
                    {
                        Console.WriteLine("Input should be Integer value, *Try again");
                    }
                    finally
                    {
                        if (dumyCourse[i] == default(int))
                        {
                            i--;
                        }
                    }
                }
            }

            onProcessCompleted("Semester Successfully read.", dumyCourse.courseID, dumyCourse.courseName, dumyCourse.instructorName, dumyCourse.numberOfCredits);
            Console.WriteLine();

            return dumyCourse;
        }

        public Semester getPrePopulatedSemester()
        {
            DateTime date = DateTime.Now;
            int month = date.Month;
            string year = Convert.ToString(date.Year);
            string semesterCode;

            if (month <= 4)
            {
                semesterCode = "Summer";
            }
            else if (month <= 8)
            {
                semesterCode = "Fall";
            }
            else
            {
                semesterCode = "Spring";
            }

            return new Semester(semesterCode, year);
        }

        public Student inputStudent()
        {
            Student dumyStudent = new Student();

            for (int i = 0; i < 7; i++)
            {
                if (i == 4)
                {
                    dumyStudent[i] = getPrePopulatedSemester();
                }

                else if (i < 4)
                {
                    Console.WriteLine(studentMassageBox[i]);
                    string temp = Console.ReadLine();
                    dumyStudent[i] = temp;

                    if (dumyStudent[i] == "None")
                    {
                        i--;
                    }
                }
                else
                {
                    Console.WriteLine(studentMassageBox[i]);
                    string temp = Console.ReadLine();
                    try
                    {
                        int val = Convert.ToInt32(temp);
                        dumyStudent[i] = temp;
                    }
                    catch
                    {
                        Console.WriteLine("Input should be integer, try again");
                    }
                    finally
                    {
                        if ((int)dumyStudent[i] == 0)
                        {
                            i--;
                        }
                    }
                }
            }

            onProcessCompleted("Student Successfully read.", dumyStudent.firstName, dumyStudent.studentID);
            Console.WriteLine();

            return dumyStudent;
        }
    }
}
