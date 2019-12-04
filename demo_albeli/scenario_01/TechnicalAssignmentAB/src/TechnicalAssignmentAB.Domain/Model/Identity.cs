namespace TechnicalAssignmentAB.Domain.Model
{
    public abstract class Identity
    {
        public long Id { get; protected set; }
        public object ActualInstance => this;

        protected Identity(long id) 
            => Id = id;

        protected Identity() { }

        public override bool Equals(object obj)
        {
            Identity newIdentity = obj as Identity;

            if (newIdentity == null)
                return false;

            if (ReferenceEquals(this, newIdentity))
                return true;

            if (ActualInstance.GetType() != newIdentity.GetType())
                return false;

            if (this.Id == 0 || newIdentity.Id == 0)
                return false;

            return Id == newIdentity.Id;
        }

        public static bool operator !=(Identity identityA, Identity identityB)
        {
            if (identityA is null && identityB is null)
                return true;

            if (identityA is null || identityB is null)
                return false;

            return identityA.Equals(identityB);
        }

        public static bool operator ==(Identity identityA, Identity identityB) 
            => !(identityA == identityB);

        public override int GetHashCode()
            => (this.Id.GetType().ToString() + 1).GetHashCode();

    }
}
