using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.CommandHandlers;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories;
using SchoolSystem.Framework.Core.Providers;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using System.IO;
using System.Reflection;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        private const string EngineName = "Engine";

        private const string CreateStudentCommandHandlerName = "CreateStudentCommandHandler";
        private const string CreateTeacherCommandHandlerName = "CreateTeacherCommandHandler";
        private const string RemoveStudentCommandHandlerName = "RemoveStudentCommandHandler";
        private const string RemoveTeacherCommandHandlerName = "RemoveTeacherCommandHandler";
        private const string StudentListMarksCommandHandlerName = "StudentListMarksCommandHandler";
        private const string TeacherAddMarkCommandHandlerName = "TeacherAddMarkCommandHandler";

        private const string CreateStudentCommandName = "CreateStudentCommand";
        private const string CreateTeacherCommandName = "CreateTeacherCommand";
        private const string RemoveStudentCommandName = "RemoveStudentCommand";
        private const string RemoveTeacherCommandName = "RemoveTeacherCommand";
        private const string StudentListMarksCommandName = "StudentListMarksCommand";
        private const string TeacherAddMarkCommandName = "TeacherAddMarkCommand";

        private const string StudentName = "Student";
        private const string TeacherName = "Teacher";
        private const string MarkName = "Mark";

        public override void Load()
        {
            //Kernel.Bind(x =>
            //{
            //    x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            //    .SelectAllClasses()
            //    .BindDefaultInterface();
            //});

            //IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            //if (configurationProvider.IsTestEnvironment)
            //{
            //}

            Bind<IEngine>().To<Engine>().InSingletonScope();
            

            Bind<ICommandHandler>().To<CreateStudentCommandHandler>().Named(CreateStudentCommandHandlerName);
            Bind<ICommandHandler>().To<CreateTeacherCommandHandler>().Named(CreateTeacherCommandHandlerName);
            Bind<ICommandHandler>().To<RemoveStudentCommandHandler>().Named(RemoveStudentCommandHandlerName);
            Bind<ICommandHandler>().To<RemoveTeacherCommandHandler>().Named(RemoveTeacherCommandHandlerName);
            Bind<ICommandHandler>().To<StudentListMarksCommandHandler>().Named(StudentListMarksCommandHandlerName);
            Bind<ICommandHandler>().To<TeacherAddMarkCommandHandler>().Named(TeacherAddMarkCommandHandlerName);

            Bind<ICommandHandler>().ToMethod(ctx =>
            {
                ICommandHandler createStudent = ctx.Kernel.Get<ICommandHandler>(CreateStudentCommandHandlerName);
                ICommandHandler createTeacher = ctx.Kernel.Get<ICommandHandler>(CreateTeacherCommandHandlerName);
                ICommandHandler removeStudent = ctx.Kernel.Get<ICommandHandler>(RemoveStudentCommandHandlerName);
                ICommandHandler removeTeacher = ctx.Kernel.Get<ICommandHandler>(RemoveTeacherCommandHandlerName);
                ICommandHandler studentListMarks = ctx.Kernel.Get<ICommandHandler>(StudentListMarksCommandHandlerName);
                ICommandHandler teacherAddMark = ctx.Kernel.Get<ICommandHandler>(TeacherAddMarkCommandHandlerName);

                createStudent.SetSuccessor(createTeacher);
                createTeacher.SetSuccessor(removeStudent);
                removeStudent.SetSuccessor(removeTeacher);
                removeTeacher.SetSuccessor(studentListMarks);
                studentListMarks.SetSuccessor(teacherAddMark);

                return createStudent;
            }).WhenInjectedInto<IParser>();

            Bind<ICommandFactory>().ToFactory().InSingletonScope();
            Bind<IPersonFactory>().ToFactory().InSingletonScope();

            Bind<ICommand>().To<CreateStudentCommand>().Named(CreateStudentCommandName);
            Bind<ICommand>().To<CreateTeacherCommand>().Named(CreateTeacherCommandName);
            Bind<ICommand>().To<RemoveStudentCommand>().Named(RemoveStudentCommandName);
            Bind<ICommand>().To<RemoveTeacherCommand>().Named(RemoveTeacherCommandName);
            Bind<ICommand>().To<StudentListMarksCommand>().Named(StudentListMarksCommandName);
            Bind<ICommand>().To<TeacherAddMarkCommand>().Named(TeacherAddMarkCommandName);

            Bind<IReader>().To<ConsoleReaderProvider>();
            Bind<IWriter>().To<ConsoleWriterProvider>();
            Bind<IParser>().To<CommandParserProvider>();

            Bind<IStudent>().To<Student>().Named(StudentName);
            Bind<ITeacher>().To<Teacher>().Named(TeacherName);

            Bind<IMarkFactory>().ToFactory();
            Bind<IMark>().To<Mark>().Named(MarkName);
        }
    }
}