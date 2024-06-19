namespace Shop.DAL.Common.RequestParams
{
   public abstract record RequestParameters
   {
      public int PageNumber { get; set; } = 1;
      public int PageSize { get; set; } = 10;
      public string? OrderBy { get; set; }
      public string? SearchTerm { get; set; }
   }
}