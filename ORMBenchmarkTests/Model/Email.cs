﻿namespace ORMBenchmarkTests.Model
{
    public class Email
    {
        public int EmailId { get; set; }

        public string EmailAddress { get; set; }

        public int EmailTypeId { get; set; }

        public EmailType EmailType { get; set; }
    }
}