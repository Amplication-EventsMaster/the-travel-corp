/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { ObjectType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";

import {
  IsDate,
  IsString,
  ValidateNested,
  IsOptional,
  IsInt,
  Min,
  Max,
  MaxLength,
  IsEnum,
} from "class-validator";

import { Type } from "class-transformer";
import { NotificationAttempt } from "../../notificationAttempt/base/NotificationAttempt";
import { ProcessorLog } from "../../processorLog/base/ProcessorLog";
import { EnumMessageQueueStatus } from "./EnumMessageQueueStatus";

@ObjectType()
class MessageQueue {
  @ApiProperty({
    required: true,
  })
  @IsDate()
  @Type(() => Date)
  @Field(() => Date)
  createdAt!: Date;

  @ApiProperty({
    required: true,
    type: String,
  })
  @IsString()
  @Field(() => String)
  id!: string;

  @ApiProperty({
    required: false,
    type: () => [NotificationAttempt],
  })
  @ValidateNested()
  @Type(() => NotificationAttempt)
  @IsOptional()
  notificationAttempts?: Array<NotificationAttempt>;

  @ApiProperty({
    required: false,
    type: Number,
  })
  @IsInt()
  @Min(-999999999)
  @Max(999999999)
  @IsOptional()
  @Field(() => Number, {
    nullable: true,
  })
  priority!: number | null;

  @ApiProperty({
    required: false,
    type: () => [ProcessorLog],
  })
  @ValidateNested()
  @Type(() => ProcessorLog)
  @IsOptional()
  processorLogs?: Array<ProcessorLog>;

  @ApiProperty({
    required: false,
    type: String,
  })
  @IsString()
  @MaxLength(1000)
  @IsOptional()
  @Field(() => String, {
    nullable: true,
  })
  queueName!: string | null;

  @ApiProperty({
    required: false,
    enum: EnumMessageQueueStatus,
  })
  @IsEnum(EnumMessageQueueStatus)
  @IsOptional()
  @Field(() => EnumMessageQueueStatus, {
    nullable: true,
  })
  status?: "Option1" | null;

  @ApiProperty({
    required: true,
  })
  @IsDate()
  @Type(() => Date)
  @Field(() => Date)
  updatedAt!: Date;
}

export { MessageQueue as MessageQueue };
