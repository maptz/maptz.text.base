using System.Linq;
using Xunit;

namespace Maptz.Text.CamelCasing.Tests
{

    public class CamelStringTests
    {
        /* #region Public Methods */
        [Fact]
        public void CamelString_Works_AsExpected()
        {
            /* #region Arrange */
            var camelString = new CamelString("interface ISomeThing");
            /* #endregion */

            /* #region Act */
            /* #endregion */

            /* #region Assert */
            Assert.Equal(4, camelString.CamelComponents.Count());
            /* #endregion */
        }
        /* #endregion Public Methods */
    }

    public class InterfaceHelpersTests
    {
        [Fact]
        public void CamelString_Works_AsExpected()
        {
            /* #region Arrange */
            ICamelString camelString = new CamelString("interface ISMPTETTSomeThing");

            /* #endregion */

            /* #region Act */
            camelString = InterfaceStringHelpers.TransformCS(camelString);
            /* #endregion */

            /* #region Assert */
            Assert.Equal(5, camelString.CamelComponents.Count());
            /* #endregion */
        }
    }
}