using ProjectPRN_FAP.Bussiness.DTO;

namespace ProjectPRN_FAP.Bussiness.IRepository
{
    public interface ITeacherRepository
    {
        public List<TeacherDTO> GetList();
        public TeacherDTO? GetById(int teacherId);

        public Boolean Create(TeacherDTO teacherDTO);

        public Boolean Delelte(TeacherDTO teacherDTO);

        public Boolean Update(TeacherDTO teacherDTO);
    }
}
