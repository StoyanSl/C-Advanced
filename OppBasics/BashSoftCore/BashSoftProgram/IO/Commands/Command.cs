using System;
using System.Collections.Generic;
using System.Text;
using BashSoftProgram.Exceptions;

namespace BashSoftProgram.IO.Commands
{
    public abstract class Command
    {
        private string input;
        public string Input
        {
            get
            {
                return this.input;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                this.input = value;
            }
        }

        private string[] data;
        public string[] Data
        {
            get { return this.data; }
            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }
                this.data = value;
            }
        }

        private Tester tester;
        protected Tester Tester
        {
            get { return this.tester; }
        }
        private StudentRepository repo;
        protected StudentRepository Repo
        {
            get { return this.repo; }
        }
        private IOManager inputOutputManager;
        protected IOManager InputOutputManager
        {
            get { return this.inputOutputManager; }
        }
      
      
    

        public Command(string input,string[] data, Tester tester,StudentRepository repo, IOManager iOManager)
        {
            Input = input;
            Data = data;
            this.tester = tester;
            this.repo = repo;
            this.inputOutputManager = iOManager;
        }

        public abstract void Execute();
    }
}
