# Reference
## events
<details><summary><code>client.Events.<a href="/src/ChronicleLabs/Events/EventsClient.cs">QueryEventsAsync</a>(QueryEventsRequest { ... }) -> WithRawResponseTask&lt;EventListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope events:read or events:write. Results are scoped to the tenant of the API key and ordered newest first by event time and event ID. Pass the opaque `next_cursor` as `cursor` to continue without an offset scan.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Events.QueryEventsAsync(new QueryEventsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `QueryEventsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Events.<a href="/src/ChronicleLabs/Events/EventsClient.cs">IngestEventAsync</a>(IngestRequest { ... }) -> WithRawResponseTask&lt;IngestResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope events:write.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Events.IngestEventAsync(
    new IngestRequest
    {
        Source = "support-agent",
        Topic = "conversations",
        EventType = "message.sent",
        Entities = new Dictionary<string, string>() { { "user", "usr_123" } },
        Payload = new Dictionary<object, object?>()
        {
            { "content", "Your refund is approved." },
            { "role", "assistant" },
        },
        Timestamp = new DateTime(2026, 09, 24, 14, 30, 00, 000),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `IngestRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Events.<a href="/src/ChronicleLabs/Events/EventsClient.cs">IngestEventBatchAsync</a>(IEnumerable&lt;IngestRequest&gt; { ... }) -> WithRawResponseTask&lt;IngestResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope events:write. Maximum 1000 events per batch; larger batches are rejected with 422. Request bodies over the size limit are rejected with 413. Each request consumes 10 rate-limit units.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Events.IngestEventBatchAsync(
    new List<IngestRequest>()
    {
        new IngestRequest
        {
            Source = "my-agent",
            Topic = "conversations",
            EventType = "message.sent",
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `IEnumerable<IngestRequest>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Events.<a href="/src/ChronicleLabs/Events/EventsClient.cs">StreamEventsAsync</a>(StreamEventsRequest { ... }) -> WithRawResponseStream&lt;EventResult&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope events:read or events:write. A Server-Sent Events stream of events matching the optional filters, held open indefinitely.

Opening a stream consumes 5 rate-limit units.

Each message has `event: event` and a `data` field carrying one EventResult as JSON. A comment line arrives every 15 seconds so intermediaries do not close an idle connection.

Every message carries an opaque, stream-specific `id` backed by a monotonic per-tenant delivery sequence. It records ingestion order, independently of the source event's `event_time`. Record the last id you processed and do not parse or construct it.

When `Last-Event-ID` is present, the server first establishes the live subscription, replays matching stored events strictly after that position in ascending order, and then continues with live delivery. Events committed at the history-to-live boundary may be delivered more than once, so consumers should deduplicate by `event_id`. This provides at-least-once delivery across a reconnect without leaving a gap.

Replay is limited to 1000 matching events. An older position returns 409 before the stream opens. Slow consumers are disconnected when the bounded live buffer fills and should reconnect with their last processed id. Concurrent streams are limited per tenant and may return 429 with `Retry-After`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
client.Events.StreamEventsAsync(new StreamEventsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `StreamEventsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## timeline
<details><summary><code>client.Timeline.<a href="/src/ChronicleLabs/Timeline/TimelineClient.cs">GetTimelineAsync</a>(GetTimelineRequest { ... }) -> WithRawResponseTask&lt;EventPage&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope events:read or events:write. Cursor paginated, newest first.

Pass `cursor` from `next_cursor` to read the following page, and stop when `has_more` is false. The cursor is opaque: it is a keyset over `(event_time, event_id)`, it is exclusive so a row cannot repeat across pages, and its encoding may change without notice. Do not parse or construct one.

`include_linked=true` selects a different read that also returns causally linked events. That read is not paginated: it returns one page with `has_more` false, and it cannot be combined with `limit` or `cursor`. `since` is only available on that read, because the paginated read has no time filter.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Timeline.GetTimelineAsync(
    new GetTimelineRequest { EntityType = "entity_type", EntityId = "entity_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetTimelineRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## search
<details><summary><code>client.Search.<a href="/src/ChronicleLabs/Search/SearchClient.cs">EventsAsync</a>(SearchRequest { ... }) -> WithRawResponseTask&lt;EventListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope events:read or events:write. The page size is capped at 200 and a cursor can advance through at most 1,000 relevance-ranked results. Each request consumes 5 rate-limit units.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Search.EventsAsync(new SearchRequest { Query = "query" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SearchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## discover
<details><summary><code>client.Discover.<a href="/src/ChronicleLabs/Discover/DiscoverClient.cs">ListSourcesAsync</a>() -> WithRawResponseTask&lt;SourceListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope events:read or events:write. Returns the complete source metadata set without pagination.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Discover.ListSourcesAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Discover.<a href="/src/ChronicleLabs/Discover/DiscoverClient.cs">ListEntityTypesAsync</a>() -> WithRawResponseTask&lt;EntityTypeListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope events:read or events:write. Returns the complete entity-type metadata set without pagination.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Discover.ListEntityTypesAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Discover.<a href="/src/ChronicleLabs/Discover/DiscoverClient.cs">ListEntitiesAsync</a>(ListEntitiesRequest { ... }) -> WithRawResponseTask&lt;EntityListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope events:read or events:write. Entities are ordered by event count and entity ID. The limit is capped at 200; pass `next_cursor` as `cursor`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Discover.ListEntitiesAsync(new ListEntitiesRequest { EntityType = "entity_type" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListEntitiesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Discover.<a href="/src/ChronicleLabs/Discover/DiscoverClient.cs">GetEventSchemaAsync</a>(GetEventSchemaRequest { ... }) -> WithRawResponseTask&lt;SourceSchema&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope events:read or events:write.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Discover.GetEventSchemaAsync(
    new GetEventSchemaRequest { Source = "source", EventType = "event_type" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetEventSchemaRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## links
<details><summary><code>client.Links.<a href="/src/ChronicleLabs/Links/LinksClient.cs">AddEntityRefAsync</a>(AddEntityRefRequest { ... }) -> WithRawResponseTask&lt;StatusResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope events:write.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Links.AddEntityRefAsync(
    new AddEntityRefRequest
    {
        EventId = "event_id",
        EntityType = "entity_type",
        EntityId = "entity_id",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AddEntityRefRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Links.<a href="/src/ChronicleLabs/Links/LinksClient.cs">CreateEventLinkAsync</a>(CreateLinkRequest { ... }) -> WithRawResponseTask&lt;CreateLinkResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope events:write.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Links.CreateEventLinkAsync(
    new CreateLinkRequest
    {
        SourceEventId = "source_event_id",
        TargetEventId = "target_event_id",
        LinkType = "link_type",
        Confidence = 1.1,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateLinkRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Links.<a href="/src/ChronicleLabs/Links/LinksClient.cs">LinkEntitiesAsync</a>(LinkEntityRequest { ... }) -> WithRawResponseTask&lt;LinkEntityResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope events:write.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Links.LinkEntitiesAsync(
    new LinkEntityRequest
    {
        FromEntityType = "from_entity_type",
        FromEntityId = "from_entity_id",
        ToEntityType = "to_entity_type",
        ToEntityId = "to_entity_id",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `LinkEntityRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Links.<a href="/src/ChronicleLabs/Links/LinksClient.cs">TraverseGraphAsync</a>(GraphRequest { ... }) -> WithRawResponseTask&lt;EventListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope events:read or events:write. The traversal is bounded by `max_depth`, is not cursor-paginated, and consumes 5 rate-limit units.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Links.TraverseGraphAsync(
    new GraphRequest { StartEventId = "start_event_id", Direction = GraphRequestDirection.Outgoing }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GraphRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## sdk
<details><summary><code>client.Sdk.<a href="/src/ChronicleLabs/Sdk/SdkClient.cs">IdentifyUserAsync</a>(IdentifyUserRequest { ... }) -> WithRawResponseTask&lt;AcceptedResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope users:write.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sdk.IdentifyUserAsync(new IdentifyUserRequest { UserId = "user_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `IdentifyUserRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sdk.<a href="/src/ChronicleLabs/Sdk/SdkClient.cs">TrackSignalsAsync</a>(TrackSignalsRequest { ... }) -> WithRawResponseTask&lt;AcceptedResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope signals:write. Maximum 1000 signals per request; larger batches are rejected with 422. Each request consumes 10 rate-limit units.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sdk.TrackSignalsAsync(new TrackSignalsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `TrackSignalsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sdk.<a href="/src/ChronicleLabs/Sdk/SdkClient.cs">TrackTracesAsync</a>(TrackTracesRequest { ... }) -> WithRawResponseTask&lt;AcceptedResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope traces:write. Maximum 1000 traces or total spans per request; larger batches are rejected with 422. Each request consumes 10 rate-limit units.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sdk.TrackTracesAsync(new TrackTracesRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `TrackTracesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## agents
<details><summary><code>client.Agents.<a href="/src/ChronicleLabs/Agents/AgentsClient.cs">ListAgentsAsync</a>() -> WithRawResponseTask&lt;IEnumerable&lt;AgentSummary&gt;&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Agents.ListAgentsAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/ChronicleLabs/Agents/AgentsClient.cs">SearchAgentHashIndexAsync</a>(SearchAgentHashIndexRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;HashIndexEntry&gt;&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Agents.SearchAgentHashIndexAsync(new SearchAgentHashIndexRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SearchAgentHashIndexRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/ChronicleLabs/Agents/AgentsClient.cs">SubscribeToAgentChangesAsync</a>() -> WithRawResponseStream&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
client.Agents.SubscribeToAgentChangesAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/ChronicleLabs/Agents/AgentsClient.cs">UpdateAgentAsync</a>(UpdateAgentRequest { ... }) -> WithRawResponseTask&lt;AgentSummary&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Agents.UpdateAgentAsync(new UpdateAgentRequest { Name = "name" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateAgentRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/ChronicleLabs/Agents/AgentsClient.cs">GetAgentSnapshotAsync</a>(GetAgentSnapshotRequest { ... }) -> WithRawResponseTask&lt;AgentSnapshot?&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Agents.GetAgentSnapshotAsync(new GetAgentSnapshotRequest { Name = "name" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetAgentSnapshotRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/ChronicleLabs/Agents/AgentsClient.cs">PinLatestAgentVersionAsync</a>(PinLatestAgentVersionRequest { ... }) -> WithRawResponseTask&lt;AgentSummary&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Agents.PinLatestAgentVersionAsync(new PinLatestAgentVersionRequest { Name = "name" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PinLatestAgentVersionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/ChronicleLabs/Agents/AgentsClient.cs">CreateAgentChatSessionAsync</a>(CreateAgentChatSessionRequest { ... }) -> WithRawResponseTask&lt;CreateAgentChatSessionResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Agents.CreateAgentChatSessionAsync(
    new CreateAgentChatSessionRequest { Name = "name" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateAgentChatSessionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/ChronicleLabs/Agents/AgentsClient.cs">GetAgentChatSessionAsync</a>(GetAgentChatSessionRequest { ... }) -> WithRawResponseTask&lt;AgentChatSession&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Agents.GetAgentChatSessionAsync(
    new GetAgentChatSessionRequest { Name = "name", SessionId = "session_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetAgentChatSessionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/ChronicleLabs/Agents/AgentsClient.cs">SendAgentChatMessageAsync</a>(SendAgentChatMessageRequest { ... }) -> WithRawResponseTask&lt;SendAgentChatMessageResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Agents.SendAgentChatMessageAsync(
    new SendAgentChatMessageRequest
    {
        Name = "name",
        SessionId = "session_id",
        Text = "text",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SendAgentChatMessageRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/ChronicleLabs/Agents/AgentsClient.cs">RegisterAgentArtifactAsync</a>(RegisterAgentArtifactRequest { ... }) -> WithRawResponseTask&lt;AgentVersionSummary&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope agents:write.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Agents.RegisterAgentArtifactAsync(
    new RegisterAgentArtifactRequest
    {
        Artifact = new RegisterAgentArtifactRequestArtifact
        {
            ArtifactId = "artifactId",
            ConfigHash = "configHash",
            Framework = RegisterAgentArtifactRequestArtifactFramework.VercelAiSdk,
            Model = new RegisterAgentArtifactRequestArtifactModel { Label = "label" },
            Name = "name",
            Provenance = new RegisterAgentArtifactRequestArtifactProvenance
            {
                CreatedAt = new DateTime(2024, 01, 15, 09, 30, 00, 000),
            },
            SchemaVersion = "schemaVersion",
            Tools = new List<RegisterAgentArtifactRequestArtifactToolsItem>()
            {
                new RegisterAgentArtifactRequestArtifactToolsItem { Name = "name" },
            },
            Version = "version",
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RegisterAgentArtifactRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/ChronicleLabs/Agents/AgentsClient.cs">RecordAgentRunsAsync</a>(RecordAgentRunsRequest { ... }) -> WithRawResponseTask&lt;RecordAgentRunsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires scope agents:write.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Agents.RecordAgentRunsAsync(
    new RecordAgentRunsRequest
    {
        Runs = new List<RecordAgentRunsRequestRunsItem>()
        {
            new RecordAgentRunsRequestRunsItem
            {
                ArtifactId = "artifactId",
                ConfigHash = "configHash",
                Operation = RecordAgentRunsRequestRunsItemOperation.Generate,
                RunId = "runId",
                SchemaVersion = "schemaVersion",
                StartedAt = new DateTime(2024, 01, 15, 09, 30, 00, 000),
                Status = RecordAgentRunsRequestRunsItemStatus.Started,
                ToolCalls = new List<RecordAgentRunsRequestRunsItemToolCallsItem>()
                {
                    new RecordAgentRunsRequestRunsItemToolCallsItem
                    {
                        CallId = "callId",
                        StartedAt = new DateTime(2024, 01, 15, 09, 30, 00, 000),
                        Status = RecordAgentRunsRequestRunsItemToolCallsItemStatus.Started,
                        ToolName = "toolName",
                    },
                },
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RecordAgentRunsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## datasets
<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">ListDatasetsAsync</a>(ListDatasetsRequest { ... }) -> WithRawResponseTask&lt;TaskSuitePage&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.ListDatasetsAsync(new ListDatasetsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListDatasetsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">CreateDatasetAsync</a>(CreateTaskSuitePayload { ... }) -> WithRawResponseTask&lt;TaskSuite&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.CreateDatasetAsync(new CreateTaskSuitePayload { Name = "name" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateTaskSuitePayload` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">CreateDatasetWithTraceAsync</a>(CreateTaskSuiteWithTraceRequest { ... }) -> WithRawResponseTask&lt;CreateTaskSuiteWithTraceResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.CreateDatasetWithTraceAsync(
    new CreateTaskSuiteWithTraceRequest
    {
        Dataset = new CreateTaskSuiteWithTraceRequestDataset { Name = "name" },
        Trace = new CreateTaskSuiteWithTraceRequestTrace { TraceId = "traceId" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateTaskSuiteWithTraceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">GetDatasetAsync</a>(GetDatasetRequest { ... }) -> WithRawResponseTask&lt;TaskSuiteDetail&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.GetDatasetAsync(new GetDatasetRequest { DatasetId = "dataset_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetDatasetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">ArchiveDatasetAsync</a>(ArchiveDatasetRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.ArchiveDatasetAsync(new ArchiveDatasetRequest { DatasetId = "dataset_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ArchiveDatasetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">UpdateDatasetAsync</a>(TaskSuitePatch { ... }) -> WithRawResponseTask&lt;TaskSuite&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.UpdateDatasetAsync(new TaskSuitePatch { DatasetId = "dataset_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `TaskSuitePatch` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">GetDatasetSnapshotAsync</a>(GetDatasetSnapshotRequest { ... }) -> WithRawResponseTask&lt;TaskSuiteSnapshot&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.GetDatasetSnapshotAsync(
    new GetDatasetSnapshotRequest { DatasetId = "dataset_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetDatasetSnapshotRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">ListDatasetTracesAsync</a>(ListDatasetTracesRequest { ... }) -> WithRawResponseTask&lt;TaskPage&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.ListDatasetTracesAsync(
    new ListDatasetTracesRequest { DatasetId = "dataset_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListDatasetTracesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">AddTraceToDatasetAsync</a>(AddTaskFromTraceRequest { ... }) -> WithRawResponseTask&lt;AddTaskFromTraceResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.AddTraceToDatasetAsync(
    new AddTaskFromTraceRequest { DatasetId = "dataset_id", TraceId = "traceId" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AddTaskFromTraceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">UpdateDatasetTracesAsync</a>(UpdateTracesRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.UpdateDatasetTracesAsync(
    new UpdateTracesRequest
    {
        DatasetId = "dataset_id",
        Patch = new UpdateTracesRequestPatch(),
        TraceIds = new List<string>() { "traceIds" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateTracesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">RemoveTraceFromDatasetAsync</a>(RemoveTraceFromDatasetRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.RemoveTraceFromDatasetAsync(
    new RemoveTraceFromDatasetRequest { DatasetId = "dataset_id", MembershipId = "membership_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RemoveTraceFromDatasetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">RefreshDatasetTraceAsync</a>(RefreshDatasetTraceRequest { ... }) -> WithRawResponseTask&lt;TaskMembership&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.RefreshDatasetTraceAsync(
    new RefreshDatasetTraceRequest
    {
        DatasetId = "dataset_id",
        MembershipId = "membership_id",
        Body = new RefreshMembershipRequest(),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RefreshDatasetTraceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">ListDatasetTraceEventsAsync</a>(ListDatasetTraceEventsRequest { ... }) -> WithRawResponseTask&lt;TaskEventPage&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.ListDatasetTraceEventsAsync(
    new ListDatasetTraceEventsRequest { DatasetId = "dataset_id", MembershipId = "membership_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListDatasetTraceEventsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">ListTraceDatasetMembershipsAsync</a>(ListTraceDatasetMembershipsRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;TaskMembership&gt;&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.ListTraceDatasetMembershipsAsync(
    new ListTraceDatasetMembershipsRequest { TraceId = "trace_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListTraceDatasetMembershipsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">ListDatasetTasksAsync</a>(ListDatasetTasksRequest { ... }) -> WithRawResponseTask&lt;TaskPage&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.ListDatasetTasksAsync(
    new ListDatasetTasksRequest { DatasetId = "dataset_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListDatasetTasksRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">CreateDatasetTaskAsync</a>(CreateDatasetTaskRequest { ... }) -> WithRawResponseTask&lt;Task&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.CreateDatasetTaskAsync(
    new CreateDatasetTaskRequest
    {
        DatasetId = "dataset_id",
        Body = new Dictionary<object, object?>() { { "key", "value" } },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateDatasetTaskRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">GetDatasetTaskAsync</a>(GetDatasetTaskRequest { ... }) -> WithRawResponseTask&lt;Task&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.GetDatasetTaskAsync(
    new GetDatasetTaskRequest { DatasetId = "dataset_id", MembershipId = "membership_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetDatasetTaskRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">DeleteDatasetTaskAsync</a>(DeleteDatasetTaskRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.DeleteDatasetTaskAsync(
    new DeleteDatasetTaskRequest { DatasetId = "dataset_id", MembershipId = "membership_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteDatasetTaskRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">UpdateDatasetTaskAsync</a>(UpdateDatasetTaskRequest { ... }) -> WithRawResponseTask&lt;Task&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.UpdateDatasetTaskAsync(
    new UpdateDatasetTaskRequest
    {
        DatasetId = "dataset_id",
        MembershipId = "membership_id",
        Body = new Dictionary<object, object?>() { { "key", "value" } },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateDatasetTaskRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">SetDatasetTaskVerifiersAsync</a>(SetTaskVerifiersRequest { ... }) -> WithRawResponseTask&lt;Task&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.SetDatasetTaskVerifiersAsync(
    new SetTaskVerifiersRequest
    {
        DatasetId = "dataset_id",
        MembershipId = "membership_id",
        Verifiers = new List<SetTaskVerifiersRequestVerifiersItem>()
        {
            new SetTaskVerifiersRequestVerifiersItem { ScorerId = "scorerId" },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SetTaskVerifiersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">ListDatasetTaskEventsAsync</a>(ListDatasetTaskEventsRequest { ... }) -> WithRawResponseTask&lt;TaskEventPage&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.ListDatasetTaskEventsAsync(
    new ListDatasetTaskEventsRequest { DatasetId = "dataset_id", MembershipId = "membership_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListDatasetTaskEventsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">RefreshDatasetTaskAsync</a>(RefreshDatasetTaskRequest { ... }) -> WithRawResponseTask&lt;TaskMembership&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.RefreshDatasetTaskAsync(
    new RefreshDatasetTaskRequest
    {
        DatasetId = "dataset_id",
        MembershipId = "membership_id",
        Body = new RefreshMembershipRequest(),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RefreshDatasetTaskRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">ListDatasetClustersAsync</a>(ListDatasetClustersRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;DatasetCluster&gt;&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.ListDatasetClustersAsync(
    new ListDatasetClustersRequest { DatasetId = "dataset_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListDatasetClustersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">CreateDatasetClusterAsync</a>(CreateClusterRequest { ... }) -> WithRawResponseTask&lt;DatasetCluster&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.CreateDatasetClusterAsync(
    new CreateClusterRequest
    {
        DatasetId = "dataset_id",
        Color = "color",
        Label = "label",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateClusterRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">DeleteDatasetClusterAsync</a>(DeleteDatasetClusterRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.DeleteDatasetClusterAsync(
    new DeleteDatasetClusterRequest { DatasetId = "dataset_id", ClusterId = "cluster_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteDatasetClusterRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">UpdateDatasetClusterAsync</a>(UpdateClusterRequest { ... }) -> WithRawResponseTask&lt;DatasetCluster&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.UpdateDatasetClusterAsync(
    new UpdateClusterRequest { DatasetId = "dataset_id", ClusterId = "cluster_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateClusterRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">ListDatasetSavedViewsAsync</a>(ListDatasetSavedViewsRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;DatasetSavedView&gt;&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.ListDatasetSavedViewsAsync(
    new ListDatasetSavedViewsRequest { DatasetId = "dataset_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListDatasetSavedViewsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">CreateDatasetSavedViewAsync</a>(CreateSavedViewRequest { ... }) -> WithRawResponseTask&lt;DatasetSavedView&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.CreateDatasetSavedViewAsync(
    new CreateSavedViewRequest
    {
        DatasetId = "dataset_id",
        Name = "name",
        Scope = CreateSavedViewRequestScope.Personal,
        State = new CreateSavedViewRequestState(),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateSavedViewRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">DeleteDatasetSavedViewAsync</a>(DeleteDatasetSavedViewRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.DeleteDatasetSavedViewAsync(
    new DeleteDatasetSavedViewRequest { DatasetId = "dataset_id", ViewId = "view_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteDatasetSavedViewRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">UpdateDatasetSavedViewAsync</a>(DatasetSavedViewPatch { ... }) -> WithRawResponseTask&lt;DatasetSavedView&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.UpdateDatasetSavedViewAsync(
    new DatasetSavedViewPatch { DatasetId = "dataset_id", ViewId = "view_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DatasetSavedViewPatch` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">ListDatasetVersionsAsync</a>(ListDatasetVersionsRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;TaskSuiteVersion&gt;&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.ListDatasetVersionsAsync(
    new ListDatasetVersionsRequest { DatasetId = "dataset_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListDatasetVersionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">PublishDatasetVersionAsync</a>(PublishVersionRequest { ... }) -> WithRawResponseTask&lt;TaskSuiteVersion&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.PublishDatasetVersionAsync(
    new PublishVersionRequest { DatasetId = "dataset_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PublishVersionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">GetDatasetVersionAsync</a>(GetDatasetVersionRequest { ... }) -> WithRawResponseTask&lt;TaskSuiteSnapshot&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.GetDatasetVersionAsync(
    new GetDatasetVersionRequest { DatasetId = "dataset_id", VersionId = "version_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetDatasetVersionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Datasets.<a href="/src/ChronicleLabs/Datasets/DatasetsClient.cs">ListDatasetEvaluationRunsAsync</a>(ListDatasetEvaluationRunsRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;TaskSuiteEvalRun&gt;&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Datasets.ListDatasetEvaluationRunsAsync(
    new ListDatasetEvaluationRunsRequest { DatasetId = "dataset_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListDatasetEvaluationRunsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## environments
<details><summary><code>client.Environments.<a href="/src/ChronicleLabs/Environments/EnvironmentsClient.cs">ListEnvironmentsAsync</a>() -> WithRawResponseTask&lt;ListEnvironmentsResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Environments.ListEnvironmentsAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Environments.<a href="/src/ChronicleLabs/Environments/EnvironmentsClient.cs">CreateEnvironmentAsync</a>(CreateEnvironmentRequest { ... }) -> WithRawResponseTask&lt;EnvironmentResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Environments.CreateEnvironmentAsync(
    new CreateEnvironmentRequest
    {
        Slug = "support-sandbox",
        Label = "Support sandbox",
        Description = "Isolated environment for support-agent backtests.",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateEnvironmentRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Environments.<a href="/src/ChronicleLabs/Environments/EnvironmentsClient.cs">GetEnvironmentAsync</a>(GetEnvironmentRequest { ... }) -> WithRawResponseTask&lt;EnvironmentResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Environments.GetEnvironmentAsync(
    new GetEnvironmentRequest { EnvironmentId = "environment_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetEnvironmentRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Environments.<a href="/src/ChronicleLabs/Environments/EnvironmentsClient.cs">ListEnvironmentVersionsAsync</a>(ListEnvironmentVersionsRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;EnvironmentVersionRecord&gt;&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Environments.ListEnvironmentVersionsAsync(
    new ListEnvironmentVersionsRequest { EnvironmentId = "environment_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListEnvironmentVersionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Environments.<a href="/src/ChronicleLabs/Environments/EnvironmentsClient.cs">CreateEnvironmentVersionAsync</a>(CreateEnvironmentVersionRequest { ... }) -> WithRawResponseTask&lt;EnvironmentVersionResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Environments.CreateEnvironmentVersionAsync(
    new CreateEnvironmentVersionRequest { EnvironmentId = "environment_id", Version = "version" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateEnvironmentVersionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Environments.<a href="/src/ChronicleLabs/Environments/EnvironmentsClient.cs">GetEnvironmentVersionAsync</a>(GetEnvironmentVersionRequest { ... }) -> WithRawResponseTask&lt;EnvironmentVersionResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Environments.GetEnvironmentVersionAsync(
    new GetEnvironmentVersionRequest
    {
        EnvironmentId = "environment_id",
        VersionSelector = "version_selector",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetEnvironmentVersionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Environments.<a href="/src/ChronicleLabs/Environments/EnvironmentsClient.cs">CompileEnvironmentVersionAsync</a>(CompileEnvironmentRequest { ... }) -> WithRawResponseTask&lt;CompileEnvironmentResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Environments.CompileEnvironmentVersionAsync(
    new CompileEnvironmentRequest
    {
        EnvironmentId = "environment_id",
        VersionSelector = "version_selector",
        DatasetSnapshotId = "datasetSnapshotId",
        ScenarioId = "scenarioId",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CompileEnvironmentRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## backtests
<details><summary><code>client.Backtests.<a href="/src/ChronicleLabs/Backtests/BacktestsClient.cs">GetBacktestsAvailabilityAsync</a>() -> WithRawResponseTask&lt;BacktestsAvailability&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Backtests.GetBacktestsAvailabilityAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Backtests.<a href="/src/ChronicleLabs/Backtests/BacktestsClient.cs">ListBacktestJobsAsync</a>(ListBacktestJobsRequest { ... }) -> WithRawResponseTask&lt;ListBacktestJobsResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Backtests.ListBacktestJobsAsync(new ListBacktestJobsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListBacktestJobsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Backtests.<a href="/src/ChronicleLabs/Backtests/BacktestsClient.cs">CreateBacktestJobAsync</a>(CreateBacktestJobRequest { ... }) -> WithRawResponseTask&lt;CreateBacktestJobResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns 202 after the durable job and its trials have been admitted.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Backtests.CreateBacktestJobAsync(
    new CreateBacktestJobRequest
    {
        Name = "name",
        Recipe = new CreateBacktestJobRequestRecipe
        {
            Agents = new List<CreateBacktestJobRequestRecipeAgentsItem>()
            {
                new CreateBacktestJobRequestRecipeAgentsItem
                {
                    Hue = "hue",
                    Id = "id",
                    Label = "label",
                    Notes = "notes",
                },
            },
            Data = new CreateBacktestJobRequestRecipeData
            {
                Kind = CreateBacktestJobRequestRecipeDataKind.Composed,
                Scenarios = new List<CreateBacktestJobRequestRecipeDataScenariosItem>()
                {
                    new CreateBacktestJobRequestRecipeDataScenariosItem
                    {
                        Count = 1,
                        Id = "id",
                        Kind = CreateBacktestJobRequestRecipeDataScenariosItemKind.Adversarial,
                        Label = "label",
                    },
                },
                Sources = new List<CreateBacktestJobRequestRecipeDataSourcesItem>()
                {
                    new CreateBacktestJobRequestRecipeDataSourcesItem
                    {
                        Count = 1,
                        Id = "id",
                        Kind = CreateBacktestJobRequestRecipeDataSourcesItemKind.Prod,
                        Label = "label",
                    },
                },
            },
            Graders = new List<CreateBacktestJobRequestRecipeGradersItem>()
            {
                new CreateBacktestJobRequestRecipeGradersItem
                {
                    Id = "id",
                    Kind = CreateBacktestJobRequestRecipeGradersItemKind.Rubric,
                    Label = "label",
                    Source = CreateBacktestJobRequestRecipeGradersItemSource.Proposed,
                    Weight = CreateBacktestJobRequestRecipeGradersItemWeight.Low,
                },
            },
            Mode = CreateBacktestJobRequestRecipeMode.Replay,
            Name = "name",
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateBacktestJobRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Backtests.<a href="/src/ChronicleLabs/Backtests/BacktestsClient.cs">GetBacktestJobAsync</a>(GetBacktestJobRequest { ... }) -> WithRawResponseTask&lt;BacktestJobDetailResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Backtests.GetBacktestJobAsync(new GetBacktestJobRequest { JobId = "job_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetBacktestJobRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Backtests.<a href="/src/ChronicleLabs/Backtests/BacktestsClient.cs">ListBacktestJobTrialsAsync</a>(ListBacktestJobTrialsRequest { ... }) -> WithRawResponseTask&lt;ListBacktestJobTrialsResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Backtests.ListBacktestJobTrialsAsync(
    new ListBacktestJobTrialsRequest { JobId = "job_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListBacktestJobTrialsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Backtests.<a href="/src/ChronicleLabs/Backtests/BacktestsClient.cs">GetBacktestTrialAsync</a>(GetBacktestTrialRequest { ... }) -> WithRawResponseTask&lt;BacktestTrialDetailResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Backtests.GetBacktestTrialAsync(
    new GetBacktestTrialRequest { JobId = "job_id", TrialId = "trial_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetBacktestTrialRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Backtests.<a href="/src/ChronicleLabs/Backtests/BacktestsClient.cs">CancelBacktestJobAsync</a>(CancelBacktestJobRequest { ... }) -> WithRawResponseTask&lt;CancelBacktestJobResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Backtests.CancelBacktestJobAsync(new CancelBacktestJobRequest { JobId = "job_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CancelBacktestJobRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Backtests.<a href="/src/ChronicleLabs/Backtests/BacktestsClient.cs">StreamBacktestJobEventsAsync</a>(StreamBacktestJobEventsRequest { ... }) -> WithRawResponseStream&lt;TrialEvent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
client.Backtests.StreamBacktestJobEventsAsync(
    new StreamBacktestJobEventsRequest { JobId = "job_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `StreamBacktestJobEventsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## credentials
<details><summary><code>client.Credentials.<a href="/src/ChronicleLabs/Credentials/CredentialsClient.cs">ListSdkKeysAsync</a>() -> WithRawResponseTask&lt;SdkKeyListResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Credentials.ListSdkKeysAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Credentials.<a href="/src/ChronicleLabs/Credentials/CredentialsClient.cs">CreateSdkKeyAsync</a>(CreateSdkKeyRequest { ... }) -> WithRawResponseTask&lt;CreatedSdkKey&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

The bearer secret is returned once and is not stored in plaintext.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Credentials.CreateSdkKeyAsync(
    new CreateSdkKeyRequest
    {
        Name = "name",
        Scopes = new List<CreateSdkKeyRequestScopesItem>()
        {
            CreateSdkKeyRequestScopesItem.TracesWrite,
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateSdkKeyRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Credentials.<a href="/src/ChronicleLabs/Credentials/CredentialsClient.cs">RevokeSdkKeyAsync</a>(RevokeSdkKeyRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Credentials.RevokeSdkKeyAsync(new RevokeSdkKeyRequest { KeyId = "key_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RevokeSdkKeyRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

