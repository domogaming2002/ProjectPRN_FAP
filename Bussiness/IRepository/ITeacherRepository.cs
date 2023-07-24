using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Models;

namespace ProjectPRN_FAP.Bussiness.IRepository
{
    public interface ITeacherRepository
    {
        public List<TeacherDTO> GetList();
        public TeacherDTO? GetById(int teacherId);
        TeacherDTO? GetByUserId(int userId);
        public Boolean Create(TeacherDTO teacherDTO);

        public Boolean Delelte(TeacherDTO teacherDTO);

        public Boolean Update(TeacherDTO teacherDTO);
    }
}
