﻿namespace BookStore.Data.Common.Interfaces
{
	public interface IConcurrency
	{
		int Version { get; set; }
	}
}
