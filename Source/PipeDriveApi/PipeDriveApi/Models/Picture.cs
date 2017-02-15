using System;
using System.Collections.Generic;

namespace PipeDriveApi
{
	public class Picture
	{
		public string ItemType { get; set; }
		public int ItemId { get; set; }
        public bool ActiveFlag { get; set; }
        public DateTime? AddTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int AddedByUserId { get; set; }
		public Dictionary<string, string> Pictures { get; set; }
        public int Value { get; set; }
    }
}