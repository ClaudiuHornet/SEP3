package dk.via.sep3.group1.applicationlogic.networking;

import dk.via.sep3.group1.applicationlogic.shared.Reply;
import dk.via.sep3.group1.applicationlogic.shared.Request;

public interface DataClient {
    Reply handleRequest(Request request);
}
