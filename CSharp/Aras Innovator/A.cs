using Aras.IOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Aras_Innovator
{
    internal class AA : Item
    {
        protected AA(IServerConnection serverConnection) : base(serverConnection)
        {
        }

        public Item A()
        {
            System.Diagnostics.Debugger.Break();
            var inn = this.getInnovator();
            var proj_num = this.getProperty("proj_num", "");
            if (proj_num != null)
            {
                return inn.newError("参数异常，为获取到proj_num");
            }
            
            var filesSql = $@"
			WITH TMP
			AS
			(
				SELECT
					D.ITEMTYPE
					,D.id
				FROM innovator.ACTIVITY2 A2
				LEFT JOIN innovator.ACTIVITY2_DELIVERABLE AD ON A2.ID=AD.SOURCE_ID
				JOIN innovator.DELIVERABLE D ON AD.RELATED_ID=D.id
				WHERE PROJ_NUM='{proj_num}'
				AND A2.IS_CURRENT = 1
				--AND D.ITEMTYPE='B88C14B99EF449828C5D926E39EE8B89'
				UNION 
				SELECT 
					D.ITEMTYPE
					,D.id
				FROM innovator.WBS_ELEMENT WE
				LEFT JOIN innovator.WBS_DELIVERABLE WD ON WE.id=WD.SOURCE_ID
				JOIN innovator.DELIVERABLE D ON WD.RELATED_ID=D.id
				WHERE PROJ_NUM='{proj_num}'
				AND WE.IS_CURRENT = 1
				--AND D.ITEMTYPE='B88C14B99EF449828C5D926E39EE8B89'
			)
			SELECT C.VIEW_FILE
			FROM TMP 
			LEFT JOIN innovator.CAD C ON TMP.id=C.ID
			WHERE TMP.ITEMTYPE='CCF205347C814DD1AF056875E0A880AC'
			UNION 
			SELECT DF.RELATED_ID
			FROM TMP
			LEFT JOIN innovator.DOCUMENT_FILE DF ON TMP.id=DF.SOURCE_ID
			WHERE TMP.ITEMTYPE='B88C14B99EF449828C5D926E39EE8B89'
			";
			var fileItems = inn.applySQL(filesSql);
			return fileItems;
        }

        public Item B()
        {
			//作者：庄玉
			//描述：添加默认团队Team000000000,并根据职责自动带出任务负责人。
			//日期：2023-06-29
			//版次：1


            System.Diagnostics.Debugger.Break();
            Innovator inn = this.getInnovator();

			var proj_num = this.getProperty("PROJECT_NUMBER", "");
			var proj_id = this.getID();
			if (proj_id==""||proj_num=="")
			{
				return inn.newError("添加默认团队获取参数异常");
			}

			//添加默认团队Team000000000
			var addTeamSql = $@"
			UPDATE innovator.PROJECT
			SET TEAM_ID=(
						SELECT ID 
						FROM innovator.TEAM
						WHERE [NAME]='Team000000000'
						)
			WHERE ID={proj_id}
			";
			var addTeamResult = inn.applySQL(addTeamSql);
            if (addTeamResult.isError())
            {
                return inn.newError(addTeamResult.getErrorString());
            }

			//根据职责自动带出任务负责人。
			var addManagerSql = $@"
			UPDATE innovator.ACTIVITY2
			SET MANAGED_BY_ID=(
					SELECT 
						TOP 1
						TI.RELATED_ID
					FROM innovator.TEAM T
					LEFT JOIN innovator.TEAM_IDENTITY TI ON T.ID=TI.SOURCE_ID
					WHERE T.[NAME]='Team000000000'
					AND TI.LEAD_ROLE=ACTIVITY2.LEAD_ROLE
						)
			WHERE PROJ_NUM={proj_id}
			";

            var addManagerResult = inn.applySQL(addManagerSql);
            if (addManagerResult.isError())
            {
                return inn.newError(addManagerResult.getErrorString());
            }

            return this;
		}
    }
}
