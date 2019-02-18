using System.Collections.Generic;

namespace Mvc_BO.Models
{
    public interface IAluno
    {
        List<Aluno> GetAlunos();
        void SetAluno(Aluno aluno);
        void UpdateAluno(Aluno aluno);
        void DeleteAluno(int id);
    }
}