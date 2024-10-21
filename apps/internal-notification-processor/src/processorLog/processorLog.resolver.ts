import * as graphql from "@nestjs/graphql";
import { ProcessorLogResolverBase } from "./base/processorLog.resolver.base";
import { ProcessorLog } from "./base/ProcessorLog";
import { ProcessorLogService } from "./processorLog.service";

@graphql.Resolver(() => ProcessorLog)
export class ProcessorLogResolver extends ProcessorLogResolverBase {
  constructor(protected readonly service: ProcessorLogService) {
    super(service);
  }
}
