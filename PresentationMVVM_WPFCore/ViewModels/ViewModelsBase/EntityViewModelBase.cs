using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationMVVM_WPFCore.ViewModels.ViewModelsBase
{
    public class EntityViewModelBase<TEntity> : ViewModelBase
        where TEntity : class
    {
        protected TEntity Entity { get; private set; }

        public EntityViewModelBase(TEntity entity)
        {
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }
    }
}
