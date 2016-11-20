using System.Collections.Generic;

using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core.Contracts
{
    public interface IEngine
    {

        IDictionary<int, IStudent> Students { get; }

        IDictionary<int, ITeacher> Teachers { get; }

        void Start();
    }
}
