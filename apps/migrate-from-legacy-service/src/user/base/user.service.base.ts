/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { PrismaService } from "../../prisma/prisma.service";

import {
  Prisma,
  User as PrismaUser,
  Account as PrismaAccount,
  ApiKey as PrismaApiKey,
  Availability as PrismaAvailability,
  Booking as PrismaBooking,
  Credential as PrismaCredential,
  EventType as PrismaEventType,
  Feedback as PrismaFeedback,
  Impersonation as PrismaImpersonation,
  Schedule as PrismaSchedule,
  SelectedCalendar as PrismaSelectedCalendar,
  Session as PrismaSession,
  Membership as PrismaMembership,
  Webhook as PrismaWebhook,
  Workflow as PrismaWorkflow,
  DestinationCalendar as PrismaDestinationCalendar,
} from "@prisma/client";

export class UserServiceBase {
  constructor(protected readonly prisma: PrismaService) {}

  async count(args: Omit<Prisma.UserCountArgs, "select">): Promise<number> {
    return this.prisma.user.count(args);
  }

  async users(args: Prisma.UserFindManyArgs): Promise<PrismaUser[]> {
    return this.prisma.user.findMany(args);
  }
  async user(args: Prisma.UserFindUniqueArgs): Promise<PrismaUser | null> {
    return this.prisma.user.findUnique(args);
  }
  async createUser(args: Prisma.UserCreateArgs): Promise<PrismaUser> {
    return this.prisma.user.create(args);
  }
  async updateUser(args: Prisma.UserUpdateArgs): Promise<PrismaUser> {
    return this.prisma.user.update(args);
  }
  async deleteUser(args: Prisma.UserDeleteArgs): Promise<PrismaUser> {
    return this.prisma.user.delete(args);
  }

  async findAccounts(
    parentId: number,
    args: Prisma.AccountFindManyArgs
  ): Promise<PrismaAccount[]> {
    return this.prisma.user
      .findUniqueOrThrow({
        where: { id: parentId },
      })
      .accounts(args);
  }

  async findApiKeys(
    parentId: number,
    args: Prisma.ApiKeyFindManyArgs
  ): Promise<PrismaApiKey[]> {
    return this.prisma.user
      .findUniqueOrThrow({
        where: { id: parentId },
      })
      .apiKeys(args);
  }

  async findAvailability(
    parentId: number,
    args: Prisma.AvailabilityFindManyArgs
  ): Promise<PrismaAvailability[]> {
    return this.prisma.user
      .findUniqueOrThrow({
        where: { id: parentId },
      })
      .availability(args);
  }

  async findBookings(
    parentId: number,
    args: Prisma.BookingFindManyArgs
  ): Promise<PrismaBooking[]> {
    return this.prisma.user
      .findUniqueOrThrow({
        where: { id: parentId },
      })
      .bookings(args);
  }

  async findCredentials(
    parentId: number,
    args: Prisma.CredentialFindManyArgs
  ): Promise<PrismaCredential[]> {
    return this.prisma.user
      .findUniqueOrThrow({
        where: { id: parentId },
      })
      .credentials(args);
  }

  async findEventTypes(
    parentId: number,
    args: Prisma.EventTypeFindManyArgs
  ): Promise<PrismaEventType[]> {
    return this.prisma.user
      .findUniqueOrThrow({
        where: { id: parentId },
      })
      .eventTypes(args);
  }

  async findFeedback(
    parentId: number,
    args: Prisma.FeedbackFindManyArgs
  ): Promise<PrismaFeedback[]> {
    return this.prisma.user
      .findUniqueOrThrow({
        where: { id: parentId },
      })
      .feedback(args);
  }

  async findImpersonatedBy(
    parentId: number,
    args: Prisma.ImpersonationFindManyArgs
  ): Promise<PrismaImpersonation[]> {
    return this.prisma.user
      .findUniqueOrThrow({
        where: { id: parentId },
      })
      .impersonatedBy(args);
  }

  async findImpersonatedUsers(
    parentId: number,
    args: Prisma.ImpersonationFindManyArgs
  ): Promise<PrismaImpersonation[]> {
    return this.prisma.user
      .findUniqueOrThrow({
        where: { id: parentId },
      })
      .impersonatedUsers(args);
  }

  async findSchedules(
    parentId: number,
    args: Prisma.ScheduleFindManyArgs
  ): Promise<PrismaSchedule[]> {
    return this.prisma.user
      .findUniqueOrThrow({
        where: { id: parentId },
      })
      .schedules(args);
  }

  async findSelectedCalendars(
    parentId: number,
    args: Prisma.SelectedCalendarFindManyArgs
  ): Promise<PrismaSelectedCalendar[]> {
    return this.prisma.user
      .findUniqueOrThrow({
        where: { id: parentId },
      })
      .selectedCalendars(args);
  }

  async findSessions(
    parentId: number,
    args: Prisma.SessionFindManyArgs
  ): Promise<PrismaSession[]> {
    return this.prisma.user
      .findUniqueOrThrow({
        where: { id: parentId },
      })
      .sessions(args);
  }

  async findTeams(
    parentId: number,
    args: Prisma.MembershipFindManyArgs
  ): Promise<PrismaMembership[]> {
    return this.prisma.user
      .findUniqueOrThrow({
        where: { id: parentId },
      })
      .teams(args);
  }

  async findWebhooks(
    parentId: number,
    args: Prisma.WebhookFindManyArgs
  ): Promise<PrismaWebhook[]> {
    return this.prisma.user
      .findUniqueOrThrow({
        where: { id: parentId },
      })
      .webhooks(args);
  }

  async findWorkflows(
    parentId: number,
    args: Prisma.WorkflowFindManyArgs
  ): Promise<PrismaWorkflow[]> {
    return this.prisma.user
      .findUniqueOrThrow({
        where: { id: parentId },
      })
      .workflows(args);
  }

  async getDestinationCalendar(
    parentId: number
  ): Promise<PrismaDestinationCalendar | null> {
    return this.prisma.user
      .findUnique({
        where: { id: parentId },
      })
      .destinationCalendar();
  }
}
