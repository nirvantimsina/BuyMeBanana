"use client";

import React, { useState } from "react";
import Link from "next/link";
import Image from "next/image";
import { Button } from "@/src/components/primitives/button";

// ─────────────────────────────────────────────
// TODO: replace with data fetched from public APIs
const FEATURED_CREATORS = [
  {
    name: "Mira Solano",
    category: "Ceramics & pottery",
    blurb: "Documenting a year of wheel-thrown work, glaze by glaze.",
    initials: "MS",
    nudgesThisWeek: 42,
  },
  {
    name: "Theo Okafor",
    category: "Short fiction",
    blurb: "A new story in your inbox every other Sunday.",
    initials: "TO",
    nudgesThisWeek: 18,
  },
  {
    name: "Priya Chandran",
    category: "Independent journalism",
    blurb: "Local reporting that doesn't answer to an ad budget.",
    initials: "PC",
    nudgesThisWeek: 76,
  },
  {
    name: "Sam Voss",
    category: "Modular synths",
    blurb: "Building patches and teaching others to build their own.",
    initials: "SV",
    nudgesThisWeek: 29,
  },
];

const RECENT_SUPPORTERS = ["AK", "JL", "RP", "MN"];

const STATS = [
  { value: "12,400+", label: "nudges sent" },
  { value: "2,100+", label: "creators supported" },
  { value: "94%", label: "goes directly to creators" },
];

const HOW_IT_WORKS = [
  {
    step: "01",
    title: "Set up your page",
    body: "Add your work, your story, and what support helps you make next.",
  },
  {
    step: "02",
    title: "Share it anywhere",
    body: "One link for your bio, your newsletter, wherever your people already are.",
  },
  {
    step: "03",
    title: "Get nudged",
    body: "Supporters send one-time or recurring nudges. You keep making the work.",
  },
];
// ─────────────────────────────────────────────

export default function LandingPage() {
  const [menuOpen, setMenuOpen] = useState(false);

  return (
    <div className="min-h-screen bg-bg-app text-text-main font-sans selection:bg-action-light selection:text-action-cta">
      {/* ── Nav ── */}
      <header className="border-b border-border-subtle/15">
        <div className="mx-auto max-w-6xl px-6 py-5 flex items-center justify-between">
          <Link href="/" className="flex items-center gap-2">
            <Image
              src="/logo.svg"
              alt="Nudge Logo"
              width={36}
              height={32}
              className="object-contain"
              priority
            />
            <span className="font-brand font-extrabold tracking-tight text-xl">
              Nudge
            </span>
          </Link>

          <nav className="hidden md:flex items-center gap-8 text-sm font-medium text-text-muted">
            <Link href="/explore" className="hover:text-text-main transition-colors">
              Explore
            </Link>
            <Link href="/how-it-works" className="hover:text-text-main transition-colors">
              How it works
            </Link>
          </nav>

          <div className="hidden md:flex items-center gap-3">
            <Link
              href="/auth"
              className="text-sm font-semibold text-text-main hover:text-action-cta transition-colors px-3 py-2"
            >
              Log in
            </Link>
            <Link href="/auth">
              <Button variant="nudge" className="!w-auto px-5 py-2 text-sm">
                Start your page
              </Button>
            </Link>
          </div>

          <button
            type="button"
            onClick={() => setMenuOpen((v) => !v)}
            className="md:hidden text-sm font-semibold"
            aria-expanded={menuOpen}
            aria-label="Toggle menu"
          >
            {menuOpen ? "Close" : "Menu"}
          </button>
        </div>

        {menuOpen && (
          <div className="md:hidden border-t border-border-subtle/15 px-6 py-4 flex flex-col gap-4 text-sm font-medium">
            <Link href="/explore">Explore</Link>
            <Link href="/how-it-works">How it works</Link>
            <Link href="/auth" className="text-action-cta font-semibold">
              Log in
            </Link>
            <Link href="/auth">
              <Button variant="nudge" className="!w-full py-2 text-sm">
                Start your page
              </Button>
            </Link>
          </div>
        )}
      </header>

      {/* ── Hero ── */}
      <section className="mx-auto max-w-6xl px-6 pt-16 pb-20 lg:pt-24 lg:pb-28 grid lg:grid-cols-2 gap-14 items-center">
        <div className="space-y-6">
          <h1 className="font-brand font-extrabold tracking-tight text-5xl md:text-6xl leading-[1.05] text-text-main">
            Fund your creative passions directly.
          </h1>
          <p className="max-w-md text-text-muted text-lg leading-relaxed">
            Nudge lets your community send direct support, one-time or
            recurring, so you can keep making the work only you make.
          </p>
          <div className="flex flex-wrap items-center gap-4 pt-2">
            <Link href="/auth">
              <Button variant="nudge" className="!w-auto px-7 py-3">
                Start your page
              </Button>
            </Link>
            <Link
              href="/explore"
              className="text-sm font-semibold text-text-main border-b border-text-main/30 hover:border-text-main pb-0.5 transition-colors"
            >
              Explore creators
            </Link>
          </div>
        </div>

        {/* Live-feeling proof card, not a generic stat box */}
        <div className="relative">
          <div className="bg-bg-surface border border-border-subtle/20 rounded-2xl p-7 shadow-sm">
            <div className="flex items-center gap-3">
              <div className="w-12 h-12 rounded-full bg-action-light flex items-center justify-center font-brand font-bold text-action-cta">
                PC
              </div>
              <div>
                <p className="font-semibold text-text-main">Priya Chandran</p>
                <p className="text-sm text-text-muted">Independent journalism</p>
              </div>
            </div>

            <div className="mt-6 flex items-baseline gap-2">
              <span className="font-brand font-extrabold text-4xl text-text-main">
                76
              </span>
              <span className="text-sm text-text-muted">nudges this week</span>
            </div>

            <div className="mt-5 flex items-center gap-2">
              <div className="flex -space-x-2">
                {RECENT_SUPPORTERS.map((initials) => (
                  <div
                    key={initials}
                    className="w-8 h-8 rounded-full bg-bg-app border-2 border-bg-surface flex items-center justify-center text-xs font-semibold text-text-muted"
                  >
                    {initials}
                  </div>
                ))}
              </div>
              <span className="text-sm text-text-muted">
                and 38 others sent a nudge this week
              </span>
            </div>
          </div>

          <div className="absolute -bottom-4 -left-4 bg-action-cta text-bg-surface rounded-xl px-4 py-3 text-sm font-semibold shadow-sm hidden sm:block">
            + $5 nudge received
          </div>
        </div>
      </section>

      {/* ── Stats strip ── */}
      <section className="border-y border-border-subtle/15 bg-bg-surface">
        <div className="mx-auto max-w-6xl px-6 py-10 flex flex-col sm:flex-row divide-y sm:divide-y-0 sm:divide-x divide-border-subtle/20">
          {STATS.map((stat) => (
            <div key={stat.label} className="flex-1 py-4 sm:py-0 sm:px-8 first:pl-0">
              <p className="font-brand font-extrabold text-3xl text-text-main">
                {stat.value}
              </p>
              <p className="text-sm text-text-muted mt-1">{stat.label}</p>
            </div>
          ))}
        </div>
      </section>

      {/* ── Featured creators ── */}
      <section className="mx-auto max-w-6xl px-6 py-20">
        <div className="flex items-end justify-between mb-8">
          <h2 className="font-brand font-extrabold text-3xl tracking-tight">
            Creators finding support here
          </h2>
          <Link
            href="/explore"
            className="hidden sm:block text-sm font-semibold text-text-main border-b border-text-main/30 hover:border-text-main pb-0.5"
          >
            See all
          </Link>
        </div>

        <div className="flex gap-5 overflow-x-auto pb-4 -mx-6 px-6 snap-x">
          {FEATURED_CREATORS.map((creator) => (
            <div
              key={creator.name}
              className="snap-start shrink-0 w-72 bg-bg-surface border border-border-subtle/20 rounded-2xl p-6 flex flex-col"
            >
              <div className="w-11 h-11 rounded-full bg-action-light flex items-center justify-center font-brand font-bold text-action-cta mb-4">
                {creator.initials}
              </div>
              <p className="font-semibold text-text-main">{creator.name}</p>
              <p className="text-sm text-text-muted">{creator.category}</p>
              <p className="text-sm text-text-muted mt-3 leading-relaxed flex-1">
                {creator.blurb}
              </p>
              <div className="mt-5 flex items-center justify-between">
                <span className="text-xs text-text-muted">
                  {creator.nudgesThisWeek} nudges this week
                </span>
                <button className="text-sm font-semibold text-action-cta hover:text-action-hover transition-colors">
                  Support
                </button>
              </div>
            </div>
          ))}
        </div>
      </section>

      {/* ── How it works ── */}
      <section className="mx-auto max-w-6xl px-6 py-20 border-t border-border-subtle/15">
        <h2 className="font-brand font-extrabold text-3xl tracking-tight mb-10">
          How Nudge works
        </h2>
        <div className="grid md:grid-cols-3 gap-10">
          {HOW_IT_WORKS.map((item) => (
            <div key={item.step} className="pt-5 border-t border-border-subtle/25">
              <span className="text-sm font-semibold text-action-cta">
                {item.step}
              </span>
              <h3 className="font-brand font-bold text-xl mt-2 mb-2">
                {item.title}
              </h3>
              <p className="text-text-muted text-sm leading-relaxed max-w-xs">
                {item.body}
              </p>
            </div>
          ))}
        </div>
      </section>

      {/* ── CTA band ── */}
      <section className="mx-auto max-w-6xl px-6 pb-20">
        <div className="bg-action-cta rounded-2xl px-10 py-14 flex flex-col lg:flex-row items-start lg:items-center justify-between gap-8">
          <h2 className="font-brand font-extrabold text-3xl md:text-4xl tracking-tight text-bg-surface leading-tight max-w-lg">
            Your community already wants to help. Give them a way to.
          </h2>
          <Link href="/auth">
            <Button
              variant="nudge"
              className="w-auto! bg-bg-surface! text-action-cta! hover:bg-action-light! px-7 py-3"
            >
              Start your page
            </Button>
          </Link>
        </div>
      </section>

      {/* ── Footer ── */}
      <footer className="border-t border-border-subtle/15">
        <div className="mx-auto max-w-6xl px-6 py-10 flex flex-col sm:flex-row items-center justify-between gap-4">
          <div className="flex items-center gap-2">
            <Image
              src="/logo.svg"
              alt="Nudge Logo"
              width={24}
              height={22}
              className="object-contain"
            />
            <span className="font-brand font-bold tracking-tight text-sm">
              Nudge
            </span>
          </div>
          <p className="text-xs text-text-muted font-medium">
            &copy; {new Date().getFullYear()} Nudge. All rights reserved.
          </p>
        </div>
      </footer>
    </div>
  );
}