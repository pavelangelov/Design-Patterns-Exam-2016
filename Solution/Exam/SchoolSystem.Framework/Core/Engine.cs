﻿using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "End";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser parser;

        private IDictionary<int, ITeacher> teachers;
        private IDictionary<int, IStudent> students;

        /* Could also extract Database provider for Teachers and Students collections
           But it will become too complex for the purposes of this exam */

        public Engine(IReader readerProvider, IWriter writerProvider, IParser parserProvider)
        {
            if (readerProvider == null)
            {
                throw new ArgumentNullException($"Reader {NullProvidersExceptionMessage}");
            }

            if (writerProvider == null)
            {
                throw new ArgumentNullException($"Writer {NullProvidersExceptionMessage}");
            }

            if (parserProvider == null)
            {
                throw new ArgumentNullException($"Parser {NullProvidersExceptionMessage}");
            }

            this.reader = readerProvider;
            this.writer = writerProvider;
            this.parser = parserProvider;

            this.Teachers = new Dictionary<int, ITeacher>();
            this.Students = new Dictionary<int, IStudent>();
        }

        public IDictionary<int, ITeacher> Teachers
        {
            get
            {
                return this.teachers;
            }

            set
            {
                this.teachers = value;
            }
        }

        public IDictionary<int, IStudent> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
            }
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString == TerminationCommand)
                    {
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.writer.WriteLine(executionResult);
        }
    }
}
