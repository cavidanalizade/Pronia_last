using System;

namespace ProniaAdmin.Service
{
    public class _LayoutService
    {
        AppDBC _context;
        public _LayoutService(AppDBC context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, string>> GetSetting()
        {
            Dictionary<string, string> setting = _context.Setting.ToDictionary(s => s.Key, s => s.Value);
            return setting;

        }
    }
}
