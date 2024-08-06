using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyLife.App.Shared.Services.Content;


public interface IBaseContentService
{
	public abstract void Initialize();
	public abstract void Shutdown();

}
