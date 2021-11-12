using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FollowUpThenAPI
{
    public class User //Todo: should this be the same object as Person? (or, maybe, this class extends Person?)
    {
        [JsonProperty("id")]
        public long Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("created")]
        public string Created { get; internal set; }
        //[JsonConverter(typeof(UnixDateTimeConverter))] //Todo: this property is not a unix timestamp (like 1636396976) but is instead a time-formated string (2015-01-19 18:28:00)
        //public DateTime? Created { get; internal set; }

        [JsonProperty("primary_email")]
        public string PrimaryEmail { get; internal set; }

        [JsonProperty("emails")]
        public List<string> Emails { get; internal set; }

        [JsonProperty("is_validated")]
        public bool IsValidated { get; internal set; }

        [JsonProperty("password_set")]
        public bool PasswordSet { get; internal set; }

        [JsonProperty("timezone")]
        public string Timezone { get; internal set; }

        [JsonProperty("preferred_date_format")]
        public string PreferredDateFormat { get; internal set; }

        [JsonProperty("preferred_date_format_js")]
        public string PreferredDateFormatJs { get; internal set; }

        [JsonProperty("postpone_times")]
        public string PostponeTimes { get; internal set; } //Todo: currently this is a comma-separated-list, but maybe this should be converted to a List<string> with a custom JsonConverter

        [JsonProperty("flagged")]
        public int Flagged { get; internal set; }

        [JsonProperty("user_warning")]
        public string UserWarning { get; internal set; } //Todo: unknown type

        [JsonProperty("sender_validation")]
        public string SenderValidation { get; internal set; } //Todo: probably an enum (but I don't know the possible values)

        [JsonProperty("send_dev_errors")]
        public bool SendDevErrors { get; internal set; }

        [JsonProperty("accepted_terms")]
        public bool AcceptedTerms { get; internal set; }

        [JsonProperty("feature_usage_monthly")]
        public Usage MonthlyFeatureUsage { get; internal set; }

        [JsonProperty("billing")]
        public Billing Billing { get; internal set; }

        [JsonProperty("email_addresses")]
        public List<EmailAddress> EmailAddresses { get; internal set; }

        [JsonProperty("email")]
        public string Email { get; internal set; }

        [JsonProperty("gopher_dev")]
        public bool GopherDev { get; internal set; }

        [JsonProperty("user_hash")]
        public string UserHash { get; internal set; }

        [JsonProperty("opt_into_fut_mailbot")]
        public bool OptIntoFutMailbot { get; internal set; }

        [JsonProperty("migrated_to_v3")]
        public bool MigratedToV3 { get; internal set; }

        [JsonProperty("privacy_mode")]
        public bool PrivacyMode { get; internal set; }

        [JsonProperty("last_payment_failed")]
        public bool? LastPaymentFailed { get; internal set; } //Todo: unknown data type (guessing bool?)

        [JsonProperty("next_payment_attempt")]
        public string NextPaymentAttempt { get; internal set; } //Todo: unknown data type (maybe a date?)

        [JsonProperty("accepted_terms_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? AcceptedTermsAt { get; internal set; }

        [JsonProperty("mute_fut_tips")]
        public bool MuteFutTips { get; internal set; }

        [JsonProperty("default_daily_reminder_time")]
        public string DefaultDailyReminderTime { get; internal set; } //Todo: maybe this should be converted to an int (to represent hour) or a DateTime

        [JsonProperty("action_email_handler")]
        public string ActionEmailHandler { get; internal set; } //Todo: unknown data type (maybe enum?)

        [JsonProperty("team_owner")]
        public bool TeamOwner { get; internal set; }

        [JsonProperty("subscription_limits")]
        public SubscriptionLimits SubscriptionLimits { get; internal set; }

        [JsonProperty("referral_hash")]
        public string ReferralHash { get; internal set; }

        [JsonProperty("referred_by")]
        public string ReferredBy { get; internal set; }
    }
}
