using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class SchemaMOLFrameMenu
    {
        /// <summary>
        /// Gets or sets RowID
        /// </summary>
        public int? RowID { get; set; }
        /// <summary>
        /// Gets or sets MenuID
        /// </summary>
        /// 

        public int? MenuID { get; set; }

        /// <summary>
        /// Gets or sets MenuName
        /// </summary>
        public String MenuName { get; set; }

        /// <summary>
        /// Gets or sets IsNewFlag
        /// </summary>
        public Boolean? IsNewFlag { get; set; }

        /// <summary>
        /// Gets or sets MetaDescription
        /// </summary>
        public String MetaDescription { get; set; }

        /// <summary>
        /// Gets or sets MetaKeywords
        /// </summary>
        public String MetaKeywords { get; set; }

        /// <summary>
        /// Gets or sets MenuImage
        /// </summary>
        public String MenuImage { get; set; }

        /// <summary>
        /// Gets or sets SequenceNo
        /// </summary>
        public int? SequenceNo { get; set; }

        /// <summary>
        /// Gets or sets ParentID
        /// </summary>
        public int? ParentID { get; set; }

        /// <summary>
        /// Gets or sets RoleID
        /// </summary>
        public Guid RoleID { get; set; }

        /// <summary>
        /// Gets or sets CreatedBy
        /// </summary>
        public String CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets CreatedOn
        /// </summary>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets UpdatedBy
        /// </summary>
        public String UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets UpdatedOn
        /// </summary>
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets Active
        /// </summary>
        public Boolean? Active { get; set; }

        /// <summary>
        /// Gets or sets DeleteStatus
        /// </summary>
        public Boolean? DeleteStatus { get; set; }

        /// <summary>
        /// Gets or sets LangID
        /// </summary>
        public int? LangID { get; set; }



    }
}
