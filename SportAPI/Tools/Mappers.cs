using BLL.Models;
using DAL.Entities;
using SportAPI.Models;

namespace SportAPI.Tools
{
    public static class Mappers
    {

        //---------------TRAINING-------------
        public static TrainingDAL ToDAL(Training t)
        {
            return new TrainingDAL()
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Picture = t.Picture,
            };
        }

        //---------------PERSON---------------
        public static PersonBLL ToBll(Person p)
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
                Auth_key = p.Auth_key,
                Created_at = p.Created_at,
                Updated_at = p.Updated_at,
                Is_validate = p.Is_validate,
                Id_type_person = p.Id_type_person,
                Id_country = p.Id_country,
            };
        }

        public static Person ToAPI(PersonBLL p)
        {
            return new Person()
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

        //---------------Country---------------
        public static CountryDAL ToDAL(Country c)
        {
            return new CountryDAL()
            {
                Id = c.Id,
                Name = c.Name,
            };
        }

        public static Country ToAPI(CountryDAL c)
        {
            return new Country()
            {
                Id = c.Id,
                Name = c.Name,
            };
        }

        //---------------Exercice---------------
        public static ExerciceDAL ToDAL(Exercice e)
        {
            return new ExerciceDAL()
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Picture = e.Picture,
                Id_type_exercice = e.Id_type_exercice,
            };
        }

        //---------------Program---------------
        public static ProgramDAL ToDAL(SportAPI.Models.Program p)
        {
            return new ProgramDAL()
            {
                Id = p.Id,
                Name= p.Name,
                Nbtrainingperweek = p.Nbtrainingperweek,
                Duration = p.Duration,
                Objectif = p.Objectif,
                Id_type_program = p.Id_type_program,
                Is_my_Program = p.Is_my_Program,
                Created_by = p.Created_by,
            };
        }

        public static ProgramBLL ToBLL(SportAPI.Models.Program p)
        {
            return new ProgramBLL()
            {
                Id = p.Id,
                Name = p.Name,
                Nbtrainingperweek = p.Nbtrainingperweek,
                Duration = p.Duration,
                Objectif = p.Objectif,
                Id_type_program = p.Id_type_program,
                Is_my_Program= p.Is_my_Program,
                Created_by= p.Created_by,
            };
        }

        //---------------Sort_Exercice---------------
        public static SortExerciceDAL ToDAL(SortExercice s)
        {
            return new SortExerciceDAL()
            {
                Id = s.Id,
                Name = s.Name,
                Picture = s.Picture,
            };
        }

        //---------------Type_Exercice---------------
        public static TypeExerciceDAL ToDAL(TypeExercice t)
        {
            return new TypeExerciceDAL()
            {
                Id = t.Id,
                Name = t.Name,
                Picture = t.Picture,
                Id_sort_exercice = t.Id_sort_exercice,
            };
        }

        //---------------Type_Person---------------
        public static TypePersonDAL ToDAL(TypePerson t)
        {
            return new TypePersonDAL()
            {
                Id = t.Id,
                Name = t.Name,
            };
        }

        //---------------Type_Program---------------
        public static TypeProgramDAL ToDAL(TypeProgram t)
        {
            return new TypeProgramDAL()
            {
                Id = t.Id,
                Name = t.Name,
                Picture = t.Picture,
            };
        }

        //---------------Profil---------------
        public static ProfilDAL ToDAL(Profil p)
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

        public static Profil ToAPI(ProfilBLL p)
        {
            return new Profil()
            {
                Id = p.Id,
                Age = p.Age,
                Height = p.Height,
                Weight = p.Weight,
                Total_xp = p.Total_xp,
                Id_person = p.Id_person,
            };
        }

        public static ProfilBLL ToBLL(Profil p)
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

        //---------------Person_Program---------------
        public static PersonProgramDAL ToDAL(PersonProgram p)
        {
            return new PersonProgramDAL()
            {
                Id_person = p.Id_person,
                Id_program = p.Id_program,
            };
        }

        public static PersonProgramBLL ToBLL(PersonProgram p)
        {
            return new PersonProgramBLL()
            {
                Id_person = p.Id_person,
                Id_program = p.Id_program,
            };
        }

        public static PersonProgram ToAPI(PersonProgramBLL p)
        {
            return new PersonProgram()
            {
                Id_person = p.Id_person,
                Id_program = p.Id_program,
            };
        }

        //---------------Program_Training---------------
        public static ProgramTrainingDAL ToDAL(ProgramTraining p)
        {
            return new ProgramTrainingDAL()
            {
                Id_program = p.Id_program,
                Id_training = p.Id_training,
            };
        }

        public static ProgramTrainingBLL ToBLL(ProgramTraining p)
        {
            return new ProgramTrainingBLL()
            {
                Id_program = p.Id_program,
                Id_training = p.Id_training,
            };
        }

        public static ProgramTraining ToAPI(ProgramTrainingBLL p)
        {
            return new ProgramTraining()
            {
                Id_program = p.Id_program,
                Id_training = p.Id_training,
            };
        }

        //---------------Training_Exercice---------------
        public static TrainingExerciceBLL ToBLL(TrainingExercice t)
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

        public static TrainingExercice ToAPI(TrainingExerciceBLL t)
        {
            return new TrainingExercice()
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
        public static LoginBLL ToBLL(LoginForm l)
        {
            return new LoginBLL()
            {
                Login = l.Login,
                Password = l.Password,
            };
        }

        public static LoginForm ToAPI(LoginBLL l)
        {
            return new LoginForm()
            {
                Login = l.Login,
                Password = l.Password,
            };
        }

        //---------------TRAININGLOG---------------
        public static TrainingLogBLL ToBLL(TrainingLog t)
        {
            return new TrainingLogBLL()
            {
                Id = t.Id,
                Date = t.Date,
                Id_person = t.Id_person,
                Id_training = t.Id_training,
            };
        }

        public static TrainingLog ToAPI(TrainingLogBLL t)
        {
            return new TrainingLog()
            {
                Id = t.Id,
                Date = t.Date,
                Id_person = t.Id_person,
                Id_training = t.Id_training,
            };
        }

        //---------------EXERCICELOG---------------
        public static ExerciceLogBLL ToBLL(ExerciceLog e)
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

        public static ExerciceLog ToAPI(ExerciceLogBLL e)
        {
            return new ExerciceLog()
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

        //---------------PERFORMANCE---------------
        public static PerformanceBLL ToBLL(Performance p)
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

        public static Performance ToAPI(PerformanceBLL p)
        {
            return new Performance()
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
