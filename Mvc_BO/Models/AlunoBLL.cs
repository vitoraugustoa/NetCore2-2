using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using Mvc_BO.Services;
using MySql.Data.MySqlClient;

namespace Mvc_BO.Models
{
    public class AlunoBLL : IAluno
    {
        public void DeleteAluno(int id)
        {
            var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            var conexaoString = configuration.GetConnectionString("MysqlConnection");

            try
            {
                using (MySqlConnection connection = new MySqlConnection(conexaoString))
                {
                    MySqlCommand command = new MySqlCommand("DeleteAluno", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    MySqlParameter paramId = new MySqlParameter();
                    paramId.ParameterName = "Id2";
                    paramId.Value = id;
                    command.Parameters.Add(paramId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<Aluno> GetAlunos()
        {
            var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            var conexaoString = configuration.GetConnectionString("MysqlConnection");

            List<Aluno> alunos = new List<Aluno>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(conexaoString))
                {
                    MySqlCommand command = new MySqlCommand("GetAlunos",connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while(reader.Read()){

                        Aluno aluno = new Aluno();
                        aluno.Id = Convert.ToInt32(reader["Id"]);
                        aluno.Nome = reader["Nome"].ToString();
                        aluno.Sexo = reader["Sexo"].ToString();
                        aluno.Email = reader["Email"].ToString();
                        aluno.Nascimento = Convert.ToDateTime(reader["Nascimento"]);
                        aluno.Foto = reader["Foto"].ToString();
                        aluno.Texto = reader["Texto"].ToString();
                        alunos.Add(aluno);
                    }
                }

                return alunos;
            }
            catch (System.Exception)
            {
                throw;
            }
        }



        public void SetAluno(Aluno aluno){        
           
            /* string date = aluno.Nascimento.ToString("yyyy-MM-dd H:mm:ss"); */

            var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            var conexaoString = configuration.GetConnectionString("MysqlConnection");

            try
            {
                using(MySqlConnection connection = new MySqlConnection(conexaoString)){                   
                    
                    MySqlCommand command = new MySqlCommand("SetAluno",connection);
                    command.CommandType = CommandType.StoredProcedure;

                    MySqlParameter paramNome = new MySqlParameter();
                    paramNome.ParameterName = "Nome2";
                    paramNome.Value = aluno.Nome;
                    command.Parameters.Add(paramNome);

                    MySqlParameter paramSexo = new MySqlParameter();
                    paramSexo.ParameterName = "Sexo2";
                    paramSexo.Value = aluno.Sexo;
                    command.Parameters.Add(paramSexo);

                    MySqlParameter paramEmail = new MySqlParameter();
                    paramEmail.ParameterName = "Email2";
                    paramEmail.Value = aluno.Email;
                    command.Parameters.Add(paramEmail);

                    MySqlParameter paramNascimento = new MySqlParameter();
                    paramNascimento.ParameterName = "Nascimento2";
                    paramNascimento.Value = aluno.Nascimento;
                    command.Parameters.Add(paramNascimento);

                    MySqlParameter paramFoto = new MySqlParameter();
                    paramFoto.ParameterName = "Foto2";
                    paramFoto.Value = aluno.Foto;
                    command.Parameters.Add(paramFoto);

                    MySqlParameter paramTexto = new MySqlParameter();
                    paramTexto.ParameterName = "Texto2";
                    paramTexto.Value = aluno.Texto;
                    command.Parameters.Add(paramTexto);

                    connection.Open();
                    int valor = command.ExecuteNonQuery();

                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public void UpdateAluno(Aluno aluno)
        {
            var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            var conexaoString = configuration.GetConnectionString("MysqlConnection");

            try
            {
                using (MySqlConnection connection = new MySqlConnection(conexaoString))
                {
                    MySqlCommand command = new MySqlCommand("AtualizarAluno", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    MySqlParameter paramId = new MySqlParameter();
                    paramId.ParameterName = "Id2";
                    paramId.Value = aluno.Id;
                    command.Parameters.Add(paramId);

                    MySqlParameter paramNome = new MySqlParameter();
                    paramNome.ParameterName = "Nome2";
                    paramNome.Value = aluno.Nome;
                    command.Parameters.Add(paramNome);

                    MySqlParameter paramEmail = new MySqlParameter();
                    paramEmail.ParameterName = "Email2";
                    paramEmail.Value = aluno.Email;
                    command.Parameters.Add(paramEmail);

                    MySqlParameter paramSexo = new MySqlParameter();
                    paramSexo.ParameterName = "Sexo2";
                    paramSexo.Value = aluno.Sexo;
                    command.Parameters.Add(paramSexo);

                    MySqlParameter paramDataInscricao = new MySqlParameter();
                    paramDataInscricao.ParameterName = "Nascimento2";
                    paramDataInscricao.Value = aluno.Nascimento;
                    command.Parameters.Add(paramDataInscricao);

                    MySqlParameter paramFoto = new MySqlParameter();
                    paramFoto.ParameterName = "Foto2";
                    paramFoto.Value = aluno.Foto;
                    command.Parameters.Add(paramFoto);

                    MySqlParameter paramTexto = new MySqlParameter();
                    paramTexto.ParameterName = "Texto2";
                    paramTexto.Value = aluno.Texto;
                    command.Parameters.Add(paramTexto);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}