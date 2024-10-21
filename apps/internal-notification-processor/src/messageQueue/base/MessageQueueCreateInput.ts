/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { InputType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import {
  IsString,
  MaxLength,
  IsOptional,
  ValidateNested,
  IsInt,
  Min,
  Max,
  IsEnum,
} from "class-validator";
import { NotificationAttemptCreateNestedManyWithoutMessageQueuesInput } from "./NotificationAttemptCreateNestedManyWithoutMessageQueuesInput";
import { Type } from "class-transformer";
import { ProcessorLogCreateNestedManyWithoutMessageQueuesInput } from "./ProcessorLogCreateNestedManyWithoutMessageQueuesInput";
import { EnumMessageQueueStatus } from "./EnumMessageQueueStatus";

@InputType()
class MessageQueueCreateInput {
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
  comment?: string | null;

  @ApiProperty({
    required: false,
    type: () => NotificationAttemptCreateNestedManyWithoutMessageQueuesInput,
  })
  @ValidateNested()
  @Type(() => NotificationAttemptCreateNestedManyWithoutMessageQueuesInput)
  @IsOptional()
  @Field(() => NotificationAttemptCreateNestedManyWithoutMessageQueuesInput, {
    nullable: true,
  })
  notificationAttempts?: NotificationAttemptCreateNestedManyWithoutMessageQueuesInput;

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
  priority?: number | null;

  @ApiProperty({
    required: false,
    type: () => ProcessorLogCreateNestedManyWithoutMessageQueuesInput,
  })
  @ValidateNested()
  @Type(() => ProcessorLogCreateNestedManyWithoutMessageQueuesInput)
  @IsOptional()
  @Field(() => ProcessorLogCreateNestedManyWithoutMessageQueuesInput, {
    nullable: true,
  })
  processorLogs?: ProcessorLogCreateNestedManyWithoutMessageQueuesInput;

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
  queueName?: string | null;

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
}

export { MessageQueueCreateInput as MessageQueueCreateInput };
