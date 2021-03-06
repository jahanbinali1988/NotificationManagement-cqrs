// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: NotificationGrpc.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace NotificationManagement.Presentation.Api.GRPC.Proto {
  public static partial class NotoficationManagementService
  {
    static readonly string __ServiceName = "NotoficationManagementService";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::NotificationManagement.Presentation.Api.GRPC.Proto.SendMessageRequest> __Marshaller_SendMessageRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::NotificationManagement.Presentation.Api.GRPC.Proto.SendMessageRequest.Parser));
    static readonly grpc::Marshaller<global::NotificationManagement.Presentation.Api.GRPC.Proto.SendMessageResponse> __Marshaller_SendMessageResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::NotificationManagement.Presentation.Api.GRPC.Proto.SendMessageResponse.Parser));

    static readonly grpc::Method<global::NotificationManagement.Presentation.Api.GRPC.Proto.SendMessageRequest, global::NotificationManagement.Presentation.Api.GRPC.Proto.SendMessageResponse> __Method_SendMessage = new grpc::Method<global::NotificationManagement.Presentation.Api.GRPC.Proto.SendMessageRequest, global::NotificationManagement.Presentation.Api.GRPC.Proto.SendMessageResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendMessage",
        __Marshaller_SendMessageRequest,
        __Marshaller_SendMessageResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::NotificationManagement.Presentation.Api.GRPC.Proto.NotificationGrpcReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for NotoficationManagementService</summary>
    public partial class NotoficationManagementServiceClient : grpc::ClientBase<NotoficationManagementServiceClient>
    {
      /// <summary>Creates a new client for NotoficationManagementService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public NotoficationManagementServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for NotoficationManagementService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public NotoficationManagementServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected NotoficationManagementServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected NotoficationManagementServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::NotificationManagement.Presentation.Api.GRPC.Proto.SendMessageResponse SendMessage(global::NotificationManagement.Presentation.Api.GRPC.Proto.SendMessageRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendMessage(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::NotificationManagement.Presentation.Api.GRPC.Proto.SendMessageResponse SendMessage(global::NotificationManagement.Presentation.Api.GRPC.Proto.SendMessageRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendMessage, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::NotificationManagement.Presentation.Api.GRPC.Proto.SendMessageResponse> SendMessageAsync(global::NotificationManagement.Presentation.Api.GRPC.Proto.SendMessageRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendMessageAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::NotificationManagement.Presentation.Api.GRPC.Proto.SendMessageResponse> SendMessageAsync(global::NotificationManagement.Presentation.Api.GRPC.Proto.SendMessageRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendMessage, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override NotoficationManagementServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new NotoficationManagementServiceClient(configuration);
      }
    }

  }
}
#endregion
