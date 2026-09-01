namespace ChronicleLabs;

public partial interface ITimelineClient
{
    /// <summary>
    /// Requires scope events:read or events:write. Cursor paginated, newest first.
    ///
    /// Pass `cursor` from `next_cursor` to read the following page, and stop when `has_more` is false. The cursor is opaque: it is a keyset over `(event_time, event_id)`, it is exclusive so a row cannot repeat across pages, and its encoding may change without notice. Do not parse or construct one.
    ///
    /// `include_linked=true` selects a different read that also returns causally linked events. That read is not paginated: it returns one page with `has_more` false, and it cannot be combined with `limit` or `cursor`. `since` is only available on that read, because the paginated read has no time filter.
    /// </summary>
    WithRawResponseTask<EventPage> GetTimelineAsync(
        GetTimelineRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
