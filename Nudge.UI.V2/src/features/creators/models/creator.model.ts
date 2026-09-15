export type CreatorCategory =
  | "all"
  | "filmmakers"
  | "music"
  | "art-heritage"
  | "tech-writing";

export interface Creator {
  id: string;
  slug: string;
  /** e.g. "Storyteller", "Art & History", "Indie Folk" — shown as the card's top-left badge */
  category: string;
  name: string;
  description: string;
  nudgeCount: number;
  avatarUrl: string;
  /** e.g. "Cinema Guild" — the creator's current tier/guild label */
  tierName: string;
}

export interface CreatorListResponse {
  items: Creator[];
  total: number;
}
