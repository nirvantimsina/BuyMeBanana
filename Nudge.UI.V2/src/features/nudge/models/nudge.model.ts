export interface NudgeTier {
  id: string;
  /** e.g. "Fan", "Patron", "Producer" */
  label: string;
  amount: number;
  /** e.g. "One-time", "Recommended", "Deep Impact" */
  note: string;
}

export interface RecentNudge {
  senderName: string;
  amount: number;
  comment: string;
  /** ISO 8601 timestamp; components format this as relative time ("4m ago") */
  createdAt: string;
}

export interface NudgeCreator {
  id: string;
  slug: string;
  name: string;
  firstName: string;
  bio: string;
  avatarUrl: string;
  isVerified: boolean;
  tiers: NudgeTier[];
  recentNudge: RecentNudge | null;
}

export interface CreateNudgePayload {
  creatorId: string;
  /** Present when the sender picked a preset tier */
  tierId?: string;
  /** Present when the sender picked a custom amount instead */
  customAmount?: number;
  senderName?: string;
  comment?: string;
}

export interface CreateNudgeResult {
  id: string;
  paymentUrl: string;
}
