namespace ProjectPRN_FAP.Bussiness.DTO
{
    public class ClassTranscriptDTO
    {
        public int ClasSubjectId { get; set; }
        public TranscriptDTO TranscriptDTO { get; set; }
        public List<DetailScoreDTO> DetailScoreDTOs { get; set; }

        public bool status { get; set; } = false;
    }
}
