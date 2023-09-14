using DAL.Entities;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tools
{
    public static class Mappers
    {

        //---------------Person---------------
        public static PersonDAL ToDAL(PersonBLL p)
        {
            return new PersonDAL()
            {
                Id = p.Id,
                Lastname = p.Lastname,
                Firstname = p.Firstname,
                Mail = p.Mail,
                Login = p.Login,
                Password = p.Password,
                Password_reset_token = p.Password_reset_token,
                Auth_key = p.Auth_key,
                Created_at = p.Created_at,
                Updated_at = p.Updated_at,
                Is_validate = p.Is_validate,
                Id_type_person = p.Id_type_person,
                Id_country = p.Id_country,
            };
        }

        public static PersonBLL ToBLL(PersonDAL p)
        {
            return new PersonBLL()
            {
                Id = p.Id,
                Lastname = p.Lastname,
                Firstname = p.Firstname,
                Mail = p.Mail,
                Login = p.Login,
                Password = p.Password,
                Password_reset_token = p.Password_reset_token,
                Created_at = p.Created_at,
                Updated_at = p.Updated_at,
                Is_validate = p.Is_validate,
                Id_type_person = p.Id_type_person,
                Id_country = p.Id_country,
            };
        }

        //---------------Program---------------
        public static ProgramDAL ToDAL(ProgramBLL p)
        {
            return new ProgramDAL()
            {
                Id = p.Id,
                Name = p.Name,
                Nbtrainingperweek = p.Nbtrainingperweek,
                Duration = p.Duration,
                Objectif = p.Objectif,
                Id_type_program = p.Id_type_program,
                Is_my_Program = p.Is_my_Program,
                Created_by = p.Created_by,
            };
        }

        public static ProgramBLL ToBLL(ProgramDAL p)
        {
            return new ProgramBLL()
            {
                Id = p.Id,
                Name = p.Name,
                Nbtrainingperweek = p.Nbtrainingperweek,
                Duration = p.Duration,
                Objectif = p.Objectif,
                Id_type_program = p.Id_type_program,
                Is_my_Program = p.Is_my_Program,
                Created_by = p.Created_by,
            };
        }

        //---------------Training---------------
        public static TrainingBLL ToBLL(TrainingDAL t)
        {
            return new TrainingBLL()
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Picture = t.Picture,
            };
        }

        public static TrainingDAL ToDAL(TrainingBLL t)
        {
            return new TrainingDAL()
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Picture = t.Picture,
            };
        }

        //---------------Profil---------------
        public static ProfilDAL ToDAL(ProfilBLL p)
        {
            return new ProfilDAL()
            {
                Id = p.Id,
                Age = p.Age,
                Height = p.Height,
                Weight = p.Weight,
                Total_xp = p.Total_xp,
                Id_person = p.Id_person,
            };
        }

        public static ProfilBLL ToBLL(ProfilDAL p)
        {
            return new ProfilBLL()
            {
                Id = p.Id,
                Age = p.Age,
                Height = p.Height,
                Weight = p.Weight,
                Total_xp = p.Total_xp,
                Id_person = p.Id_person,
            };
        }

        //---------------PersonProgram---------------
        public static PersonProgramBLL ToBLL(PersonProgramDAL p)
        {
            return new PersonProgramBLL()
            {
                Id_person = p.Id_person,
                Id_program = p.Id_program,
            };
        }

        public static PersonProgramDAL ToDAL(PersonProgramBLL p)
        {
            return new PersonProgramDAL()
            {
                Id_person = p.Id_person,
                Id_program = p.Id_program,
            };
        }

        //---------------ProgramTraining---------------
        public static ProgramTrainingBLL ToBLL(ProgramTrainingDAL p)
        {
            return new ProgramTrainingBLL()
            {
                Id_training = p.Id_training,
                Id_program = p.Id_program,
            };
        }

        public static ProgramTrainingDAL ToDAL(ProgramTrainingBLL p)
        {
            return new ProgramTrainingDAL()
            {
                Id_training = p.Id_training,
                Id_program = p.Id_program,
            };
        }

        //---------------TrainingExercice---------------
        public static TrainingExerciceBLL ToBLL(TrainingExerciceDAL t)
        {
            return new TrainingExerciceBLL()
            {
                Id_training = t.Id_training,
                Id_exercice = t.Id_exercice,
                Serie = t.Serie,
                Reps = t.Reps,
                Rest = t.Rest,
                Weight = t.Weight,
                Rpe = t.Rpe,
                Distance = t.Distance,
                Time = t.Time,
                Cpt = t.Cpt,
            };
        }  

        public static TrainingExerciceDAL ToDAL(TrainingExerciceBLL t)
        {
            return new TrainingExerciceDAL()
            {
                Id_training = t.Id_training,
                Id_exercice = t.Id_exercice,
                Serie = t.Serie,
                Reps = t.Reps,
                Rest = t.Rest,
                Weight = t.Weight,
                Rpe = t.Rpe,
                Distance = t.Distance,
                Time = t.Time,
                Cpt = t.Cpt,
            };
        }

        //---------------Login---------------
        public static LoginBLL ToBLL(LoginDAL l)
        {
            return new LoginBLL()
            {
                Login = l.Login,
                Password = l.Password,
            };
        }

        public static LoginDAL ToDAL(LoginBLL l)
        {
            return new LoginDAL()
            {
                Login = l.Login,
                Password = l.Password,
            };
        }

        //---------------TrainingLog---------------
        public static TrainingLogBLL ToBLL(TrainingLogDAL t)
        {
            return new TrainingLogBLL()
            {
                Id = t.Id,
                Date = t.Date,
                Id_person = t.Id_person,
                Id_training = t.Id_training,
            };
        }

        public static TrainingLogDAL ToDAL(TrainingLogBLL t)
        {
            return new TrainingLogDAL()
            {
                Id = t.Id,
                Date = t.Date,
                Id_person = t.Id_person,
                Id_training = t.Id_training,
            };
        }

        //---------------ExerciceLog---------------
        public static ExerciceLogBLL ToBLL(ExerciceLogDAL e)
        {
            return new ExerciceLogBLL()
            {
                Id = e.Id,
                Reps = e.Reps,
                Weight = e.Weight,
                Distance = e.Distance,
                Time = e.Time,
                Comment = e.Comment,
                Id_training_log = e.Id_training_log,
                Id_exercice = e.Id_exercice,
            };
        }

        public static ExerciceLogDAL ToDAL(ExerciceLogBLL e)
        {
            return new ExerciceLogDAL()
            {
                Id = e.Id,
                Reps = e.Reps,
                Weight = e.Weight,
                Distance = e.Distance,
                Time = e.Time,
                Comment = e.Comment,
                Id_training_log = e.Id_training_log,
                Id_exercice = e.Id_exercice,
            };
        }

        //---------------Performance---------------
        public static PerformanceBLL ToBLL(PerformanceDAL p)
        {
            return new PerformanceBLL()
            {
                Id = p.Id,
                Description = p.Description,
                Value = p.Value,
                Date = p.Date,
                Id_profil = p.Id_profil,
                Id_exercice = p.Id_exercice,
            };
        }

        public static PerformanceDAL ToDAL(PerformanceBLL p)
        {
            return new PerformanceDAL()
            {
                Id = p.Id,
                Description = p.Description,
                Value = p.Value,
                Date = p.Date,
                Id_profil = p.Id_profil,
                Id_exercice = p.Id_exercice,
            };
        }
    }
}
