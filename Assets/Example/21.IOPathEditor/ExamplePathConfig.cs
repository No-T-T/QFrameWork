// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace QFramework.Example {
    
    /// <summary>
    /// 21.Example测试路径
    /// </summary>
    public class ExamplePathConfig {
        private const string m_ExampleEditorPathDir = "Example/21.IOPathEditor/ExampleEditorPathDir";
        private const string m_ExamplePersistentPathDir = "21.IOPathEditor/ExamplePersistentPathDir";
        /// <summary>
        /// 正常路径
        /// </summary>
        public static string ExampleEditorPathDir {
            get {
                return QFramework.Libs.IOUtils.CreateDirIfNotExists ("Assets/" + m_ExampleEditorPathDir);
            }
        }
        /// <summary>
        /// 生成UI脚本的路径
        /// </summary>
        public static string ExamplePersistentPathDir {
            get {
                return QFramework.Libs.IOUtils.CreateDirIfNotExists (UnityEngine.Application.persistentDataPath + "/" + m_ExamplePersistentPathDir);
            }
        }
    }
}
