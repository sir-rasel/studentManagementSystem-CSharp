using System.Collections.Generic;

namespace StudentManagementSystem
{
    interface ICreateObject
    {
        public dynamic createDeepCopy();
    }

    interface IFormatedOutput
    {
        public void getFormatedOutput();
    }

    interface IFileManager
    {
        public dynamic readFiles(string fileName, string type);
        public void writeFiles(string fileName, List<dynamic> lines);
    }
}
