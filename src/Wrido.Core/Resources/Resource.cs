﻿using System;

namespace Wrido.Core.Resources
{
  public abstract class Resource
  {
    public string Key { get; set; }
  }

  public sealed class ImageResource : Resource
  {
    public Uri Uri { get; set; }
    public string Alt { get; set; }
  }
}
