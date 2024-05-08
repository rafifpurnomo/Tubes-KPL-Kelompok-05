using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAIN_TUBES_KPL_KELOMPOK_5
{
    internal class AkkunManager
    {
        public enum VerificationStatus
        {
            Unverified,
            Pending,
            Verified,
            Rejected
        }

        public enum VerificationEvent
        {
            Submit,
            Approve,
            Reject
        }

        public enum MemberStatus
        {
            Unverified,
            Active,
            Inactive,
            Frozen
        }

        public class VerificationStateMachine
        {
            private VerificationStatus _currentStatus;

            public VerificationStateMachine()
            {
                // Saat inisialisasi, status verifikasi diatur ke Unverified
                _currentStatus = VerificationStatus.Unverified;
            }

            public VerificationStatus CurrentStatus
            {
                get { return _currentStatus; }
            }

            public void ProcessEvent(VerificationEvent verificationEvent)
            {
                switch (_currentStatus)
                {
                    case VerificationStatus.Unverified:
                        if (verificationEvent == VerificationEvent.Submit)
                            _currentStatus = VerificationStatus.Pending;
                        break;
                    case VerificationStatus.Pending:
                        if (verificationEvent == VerificationEvent.Approve)
                            _currentStatus = VerificationStatus.Verified;
                        else if (verificationEvent == VerificationEvent.Reject)
                            _currentStatus = VerificationStatus.Rejected;
                        break;
                    case VerificationStatus.Verified:
                        // Tidak ada transisi tambahan setelah verifikasi berhasil
                        break;
                    case VerificationStatus.Rejected:
                        // Tidak ada transisi tambahan setelah verifikasi ditolak
                        break;
                }
            }
        }
    }
}
