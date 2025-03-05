namespace hoicham.Core.Application.DTOs.ResponseDTOs
{
	public class ResultDto<T>
	{
		public bool Success { get; set; }
		public string Message { get; set; }
		public T Data { get; set; }
		public List<string> Errors { get; set; } = new List<string>();
	}
}
