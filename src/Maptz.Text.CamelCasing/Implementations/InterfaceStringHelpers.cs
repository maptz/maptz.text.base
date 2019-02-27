using System;
using System.Collections.Generic;
using System.Linq;
namespace Maptz.Text.CamelCasing
{

    public static class InterfaceStringHelpers
    {
        public static ICamelString TransformCS(ICamelString camelString)
        {
            var retval = new CamelString(string.Empty);
            var retvalComponents = (IList<ICamelComponent>)retval.CamelComponents;
            foreach (var component in camelString.CamelComponents)
            {
                var isInterfaceDefinition = component.AreAllCharsLettersOrDigits && component.Text.Length > 2 && component.Text[0] == 'I' && component.Text[1].ToString().ToUpper() == component.Text[1].ToString();
                if (isInterfaceDefinition)
                {
                    var component1 = new CamelComponent();
                    component1.AddChar(component.Text[0]);
                    retvalComponents.Add(component1);

                    var component2 = new CamelComponent();
                    for (int i = 1; i < component.Text.Length; i++)
                    {
                        component2.AddChar(component.Text[i]);
                    }
                    retvalComponents.Add(component2);
                }
                else
                {
                    retvalComponents.Add(component);
                }
            }
            return retval;
        }
    }
}