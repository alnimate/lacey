using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lacey.Alexa.Common.Metasploit.Manager
{
	internal class MetasploitProManager : MetasploitManager
	{
		MetasploitSession _session;
		
		public MetasploitProManager (MetasploitSession session) : base(session)
		{
			_session = session;
		}
		
		public async Task<Dictionary<string, object>> AboutPro()
		{
			return await _session.Execute("pro.about");
		}
		
		public async Task<Dictionary<string, object>> ListProWorkspaces()
		{
			return await _session.Execute("pro.workspaces");
		}
		
		public async Task<Dictionary<string, object>> ListProProjects()
		{
			return await _session.Execute("pro.projects");
		}
		
		public async Task<Dictionary<string, object>> AddProWorkspace(Dictionary<string, object> options)
		{
			return await _session.Execute("pro.workspace_add", options);
		}
		
		public async Task<Dictionary<string, object>> AddProProject(Dictionary<string, object> options)
		{
			return await _session.Execute("pro.project_add", options);
		}
		
		public async Task<Dictionary<string, object>> DeleteProWorkspace(string workspaceName)
		{
			return await _session.Execute("pro.workspace_del", workspaceName);
		}
		
		public async Task<Dictionary<string, object>> DeleteProProject(string workspaceName)
		{
			return await _session.Execute("pro.project_del", workspaceName);
		}
		
		public async Task<Dictionary<string, object>> GetProUsers()
		{
			return await _session.Execute("pro.users");
		}
		
		public async Task<Dictionary<string, object>> RegisterPro(string productKey)
		{
			return await _session.Execute("pro.register", productKey);
		}
		
		public async Task<Dictionary<string, object>> ActivatePro(Dictionary<string, object> options)
		{
			return await _session.Execute("pro.activate", options);
		}
		
		public async Task<Dictionary<string, object>> ActivateProOffline(string activationPath)
		{
			return await _session.Execute("pro.activate_offline", activationPath );
		}
		
		public async Task<Dictionary<string, object>> GetProLicense()
		{
			return await _session.Execute("pro.license");
		}
		
		public async Task<Dictionary<string, object>> RevertProLicense()
		{
			return await _session.Execute("pro.revert_license");
		}
		
		public async Task<Dictionary<string, object>> ProUpdatesAvailable(Dictionary<string, object> options)
		{
			return await _session.Execute("pro.update_available", options);
		}
		
		public async Task<Dictionary<string, object>> ProInstallUpdates(Dictionary<string, object> options)
		{
			return await _session.Execute("pro.update_install", options);
		}
		
		public async Task<Dictionary<string, object>> ProInstallOfflineUpdates(string updatePath)
		{
			return await _session.Execute("pro.update_install_offline", updatePath);
		}
		
		public async Task<Dictionary<string, object>> ProUpdateStatus()
		{
			return await _session.Execute("pro.update_status");
		}
		
		public async Task<Dictionary<string, object>> ProStopUpdates()
		{
			return await _session.Execute("pro.update_stop");
		}
		
		public async Task<Dictionary<string, object>> RestartPro()
		{
			return await _session.Execute("pro.restart_service");
		}
		
		public async Task<Dictionary<string, object>> GetProTasks()
		{
			return await _session.Execute("pro.task_list");
		}
		
		public async Task<Dictionary<string, object>> GetProTaskStatus(string taskId)
		{
			return await _session.Execute("pro.task_status", taskId);
		}
		
		public async Task<Dictionary<string, object>> StopProTask(string taskId)
		{
			return await _session.Execute("pro.task_stop", taskId);
		}
		
		public async Task<Dictionary<string, object>> GetProTaskLog(string taskId)
		{
			return await _session.Execute("pro.task_log", taskId);
		}
		
		public async Task<Dictionary<string, object>> DeleteProTaskLog(string taskId)
		{
			return await _session.Execute("pro.task_delete_log");
		}
		
		public async Task<Dictionary<string, object>> StartDiscover(Dictionary<string, object> options)
		{
			return await _session.Execute("pro.start_discover", options);
		}
		
		public async Task<Dictionary<string, object>> StartImport(Dictionary<string, object> options)
		{
			return await _session.Execute("pro.start_import", options);
		}
		
		public async Task<Dictionary<string, object>> StartCredentialImport(Dictionary<string, object> options)
		{
			return await _session.Execute("pro.start_import_creds", options);
		}
		
		public async Task<Dictionary<string, object>> StartNexposeAssessment(Dictionary<string, object> options)
		{
			return await _session.Execute("pro.start_nexpose", options);
		}
		
		public async Task<Dictionary<string, object>> StartBruteforce(Dictionary<string, object> options)
		{
			return await _session.Execute("pro.start_bruteforce", options);
		}
		
		public async Task<Dictionary<string, object>> StartExploit(Dictionary<string, object> options)
		{
			return await _session.Execute("pro.start_exploit", options);
		}
		
		public async Task<Dictionary<string, object>> StartWebscan(Dictionary<string, object> options)
		{
			return await _session.Execute("pro.start_webscan", options);
		}
		
		public async Task<Dictionary<string, object>> StartWebAudit(Dictionary<string, object> options)
		{
			return await _session.Execute("pro.start_webaudit", options);
		}
		
		public async Task<Dictionary<string, object>> StartWebSploit(Dictionary<string, object> options)
		{
			return await _session.Execute("pro.start_websploit", options);
		}
		
		public async Task<Dictionary<string, object>> StartCleanup(Dictionary<string, object> options)
		{
			return await _session.Execute("pro.start_cleanup", options);
		}
		
		public async Task<Dictionary<string, object>> StartLootCollection(Dictionary<string, object> options)
		{
			return await _session.Execute("pro.start_collect", options);
		}

		public async Task<Dictionary<string, object>> StartSingle (Dictionary<string, object> options)
		{
			return await _session.Execute("pro.start_single", options);
		}

		public async Task<Dictionary<string, object>> StartReport(Dictionary<string, object> options)
		{
			return await _session.Execute("pro.start_report", options);
		}
		
		public async Task<Dictionary<string, object>> ImportData(string workspace, string data, Dictionary<string, object> options)
		{
			return await _session.Execute("pro.import_data", workspace, data, options);
		}
		
		public async Task<Dictionary<string, object>> ImportFile(string workspace, string path, Dictionary<string, object> options)
		{
			return await _session.Execute("pro.import_file", workspace, path, options);
		}
		
		public async Task<Dictionary<string, object>> ValidateImportFile(string filepath)
		{
			return await _session.Execute("pro.validate_import_file", filepath);
		}
		
		public async Task<Dictionary<string, object>> DownloadLoot(int lootId)
		{
			return await _session.Execute("pro.loot_download", lootId);
		}
		
		public async Task<Dictionary<string, object>> ListLoot(string workspace)
		{
			return await _session.Execute("pro.loot_list", workspace);
		}
		
		public async Task<Dictionary<string, object>> SearchProModules(string query)
		{
			return await _session.Execute("pro.module_search", query);
		}
		
		public async Task<Dictionary<string, object>> ValidateProModule(string moduleName, Dictionary<string, object> options)
		{
			return await _session.Execute("pro.module_validate", moduleName, options);
		}
		
		public async Task<Dictionary<string, object>> ListProModules()
		{
			return await _session.Execute("pro.report_list");
		}
		
		public async Task<Dictionary<string, object>> DownloadReport(string reportId)
		{
			return await _session.Execute("pro.report_download");
		}
		
		public async Task<Dictionary<string, object>> DownloadReportByTask(string taskId)
		{
			return await _session.Execute("pro.report_download_by_task", taskId);
		}
		
		public async Task<Dictionary<string, object>> GetReportList(string workspace)
		{
			return await _session.Execute("pro.report_list", workspace);
		}
		
		public async Task<Dictionary<string, object>> MeterpreterChDir(string sessionId, string path)
		{
			return await _session.Execute("pro.meterpreter_chdir", sessionId, path);
		}
		
		public async Task<Dictionary<string, object>> MeterpreterGetCwd(string sessionId)
		{
			return await _session.Execute("pro.meterpreter_getcwd", sessionId);
		}
		
		public async Task<Dictionary<string, object>> MeterpreterListDirectory(string sessionId, string path)
		{
			return await _session.Execute("pro.meterpreter_list", sessionId, path);
		}
		
		public async Task<Dictionary<string, object>> MeterpreterRemoveFileOrDirectory(string sessionId, string path)
		{
			return await _session.Execute("pro.meterpreter_rm", sessionId, path);
		}
		
		public async Task<Dictionary<string, object>> MeterpreterRootPaths(string sessionId)
		{
			return await _session.Execute("pro.meterpreter_root_paths", sessionId);
		}
		
		public async Task<Dictionary<string, object>> MeterpreterSearch(string sessionId, string query)
		{
			return await _session.Execute("pro.meterpreter_search", sessionId, query);
		}
		
		public async Task<Dictionary<string, object>> MeterpreterTunnelInterfaces(string sessionId)
		{
			return await _session.Execute("pro.meterpreter_tunnel_interfaces", sessionId);
		}
	}
}

