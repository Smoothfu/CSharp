﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    //a custom attribute BugFix to be assigned to a class and its members
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Field |
        AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
    public class DebugInfoAttribute : Attribute
    {
        private int bugNo;
        private string developer;
        private string lastReview;
        public string message;
        public DebugInfoAttribute(int bg, string dev, string date)
        {
            this.bugNo = bg;
            this.developer = dev;
            this.lastReview = date;
        }

        public int BugNo
        {
            get;
            private set;
        }

        public string Developer
        {
            get;
            private set;
        }

        public string LastReview
        {
            get;
            private set;
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

    }
}
